using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    [RequireComponent(typeof(AosCommandQueueHandler))]
    public class WebSocketWrapper : MonoBehaviour
    {
        public static WebSocketWrapper Instance;

        private Socket _serverSocket;
        private Socket _currentClientSocket;

        private IPEndPoint _ipEndPoint;

        private readonly byte[] _buffer = new byte[8192];

        private readonly List<byte> _received = new List<byte>();

        private AosCommandQueueHandler _aosCommandQueueHandler;

        public delegate void SocketMessageReceivedHandler(string message);

        public delegate void SocketMessageSentHandler();

        public delegate void SocketClientConnected();

        public event SocketMessageReceivedHandler OnClientMessageReceived;
        public event SocketMessageSentHandler OnClientMessageSent;
        public event SocketClientConnected OnClientConnected;

        public void Init(IPEndPoint ipEndPoint)
        {
            OnClientMessageReceived -= ClientMessageReceived;
            OnClientMessageSent -= ClientMessageSent;

            _aosCommandQueueHandler = GetComponent<AosCommandQueueHandler>();

            _ipEndPoint = ipEndPoint;

            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _serverSocket.Bind(ipEndPoint);
            _serverSocket.Listen(128);

            BeginAcceptClients();

            OnClientMessageReceived += ClientMessageReceived;
            OnClientMessageSent += ClientMessageSent;

            if (Instance == null)
            {
                Instance = this;
            }

            Debug.Log("AosSdk: web socket server is ready");
        }

        private void BeginAcceptClients()
        {
            _serverSocket.BeginAccept(null, 0, ClientConnectedCallback, null);
        }

        private static void ClientMessageSent()
        {
            Debug.Log("AosSdk: Sent message to client.");
        }

        private void ClientMessageReceived(string message)
        {
            AosCommand aosCommandToQueue = null;
            try
            {
                aosCommandToQueue = JsonConvert.DeserializeObject<AosCommand>(message);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error parsing AOSCommand: {message}: {e.Message}");
            }
            finally
            {
                _aosCommandQueueHandler.CommandQueue.Add(aosCommandToQueue);
            }
        }

        public void DoSendMessage(object message)
        {
            var encodeMessageToSend = EncodeMessage(JsonUtility.ToJson(message, true));

            if (_currentClientSocket == null)
            {
                Debug.LogError("AosSdk: Cant send message to client: no client connected");
                return;
            }

            _currentClientSocket.BeginSend(encodeMessageToSend, 0, encodeMessageToSend.Length, 0, MessageSendCallback,
                _currentClientSocket);
        }

        private void MessageSendCallback(IAsyncResult ar)
        {
            try
            {
                if (!(ar.AsyncState is Socket client))
                {
                    return;
                }

                var bytesSent = client.EndSend(ar);
                if (bytesSent == 0)
                {
                    return;
                }

                OnClientMessageSent?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        private void ClientConnectedCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = null;

                if (_serverSocket is {IsBound: true})
                {
                    client = _serverSocket.EndAccept(ar);
                }

                if (client == null)
                {
                    return;
                }

                var headerResponse = "";
                while (true)
                {
                    var messageLength = client.Receive(_buffer);
                    if (0 == messageLength)
                    {
                        return;
                    }

                    headerResponse += Encoding.UTF8.GetString(_buffer).Substring(0, messageLength);
                    if (new Regex("\r\n\r\n$").IsMatch(headerResponse))
                    {
                        break;
                    }
                }

                var handshakeResponse = GetHandshakeData(headerResponse);

                if (handshakeResponse.Length == 0)
                {
                    return;
                }

                client.Send(handshakeResponse);

                _currentClientSocket = client;

                Debug.Log("AosSdk: web socket client connected");
                OnClientConnected?.Invoke();

                _currentClientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, MessageReceivedCallback,
                    _currentClientSocket);
            }
            catch (SocketException exception)
            {
                Debug.LogError(exception.ToString());
            }
            finally
            {
                if (_serverSocket is {IsBound: true})
                {
                    _serverSocket.BeginAccept(null, 0, ClientConnectedCallback, null);
                }
            }
        }

        private void MessageReceivedCallback(IAsyncResult result)
        {
            var client = result.AsyncState as Socket;
            var disconnected = new bool();

            try
            {
                if (client == null)
                {
                    return;
                }

                var received = client.EndReceive(result);
                _received.AddRange(_buffer.Take(received));

                int decoded;
                do
                {
                    decoded = DecodeMessage(_received.ToArray(), out var message, out disconnected);

                    if (decoded > 0)
                    {
                        OnClientMessageReceived?.Invoke(message);
                        _received.RemoveRange(0, decoded);
                    }
                    else if (disconnected)
                    {
                        _received.Clear();
                        client.BeginDisconnect(false, ClientDisconnectCallback, client);
                    }
                } while (decoded > 0 && _received.Any());
            }
            catch (SocketException exception)
            {
                Debug.LogError(exception.ToString());
            }
            finally
            {
                if (!disconnected)
                {
                    client?.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, MessageReceivedCallback, client);
                }
            }
        }

        private static void ClientDisconnectCallback(IAsyncResult ar)
        {
            try
            {
                if (!(ar.AsyncState is Socket client))
                {
                    Debug.LogError("AosSdk: Can't disconnect, client is null");
                    return;
                }

                client.EndDisconnect(ar);

                Debug.Log("AosSdk: web socket client disconnected");
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        private static int DecodeMessage(IReadOnlyList<byte> bytes, out string message, out bool disconnect)
        {
            message = string.Empty;
            disconnect = false;

            var opCode = bytes[0] & 0x0f;
            if (0x08 == opCode)
            {
                disconnect = true;
                return 0;
            }

            var secondByte = bytes[1];
            long dataLength = (secondByte & 127) switch
            {
                126 => (bytes[2] << 8) + bytes[3],
                127 => (bytes[2] << 56) + (bytes[3] << 48) + (bytes[4] << 40) + (bytes[5] << 32) + (bytes[6] << 24) + (bytes[7] << 16) + (bytes[8] << 8) + bytes[9],
                _ => secondByte & 127
            };
            var indexFirstMask = (secondByte & 127) switch
            {
                126 => 4,
                127 => 10,
                _ => 2
            };
            if (indexFirstMask + 4 + dataLength > bytes.Count)
            {
                return 0;
            }

            var keys = bytes.Skip(indexFirstMask).Take(4);
            var indexFirstDataByte = indexFirstMask + 4;

            var decoded = new byte[dataLength];
            for (int i = indexFirstDataByte, j = 0; i < dataLength + indexFirstDataByte; i++, j++)
            {
                decoded[j] = (byte) (bytes[i] ^ keys.ElementAt(j % 4));
            }

            message = Encoding.UTF8.GetString(decoded, 0, decoded.Length);

            return indexFirstMask + 4 + (int) dataLength;
        }

        private static byte[] EncodeMessage(string message)
        {
            var bytesRaw = Encoding.UTF8.GetBytes(message);
            var frame = new byte[10];

            int indexStartRawData;
            var length = bytesRaw.Length;

            frame[0] = 129;
            if (length <= 125)
            {
                frame[1] = (byte) length;
                indexStartRawData = 2;
            }
            else if (length <= 65535)
            {
                frame[1] = 126;
                frame[2] = (byte) ((length >> 8) & 255);
                frame[3] = (byte) (length & 255);
                indexStartRawData = 4;
            }
            else
            {
                frame[1] = 127;
                frame[2] = (byte) ((length >> 56) & 255);
                frame[3] = (byte) ((length >> 48) & 255);
                frame[4] = (byte) ((length >> 40) & 255);
                frame[5] = (byte) ((length >> 32) & 255);
                frame[6] = (byte) ((length >> 24) & 255);
                frame[7] = (byte) ((length >> 16) & 255);
                frame[8] = (byte) ((length >> 8) & 255);
                frame[9] = (byte) (length & 255);

                indexStartRawData = 10;
            }

            var response = new byte[indexStartRawData + length];

            int i, responseIdx = 0;

            for (i = 0; i < indexStartRawData; i++)
            {
                response[responseIdx] = frame[i];
                responseIdx++;
            }

            for (i = 0; i < length; i++)
            {
                response[responseIdx] = bytesRaw[i];
                responseIdx++;
            }

            return response;
        }

        private static byte[] GetHandshakeData(string data)
        {
            if (!new Regex("^GET").IsMatch(data))
            {
                return Array.Empty<byte>();
            }

            var eol = Environment.NewLine;

            var response = Encoding.UTF8.GetBytes("HTTP/1.1 101 Switching Protocols" + eol + "Connection: Upgrade" +
                                                  eol + "Upgrade: websocket" + eol + "Sec-WebSocket-Accept: " +
                                                  Convert.ToBase64String(System.Security.Cryptography.SHA1.Create()
                                                      .ComputeHash(Encoding.UTF8.GetBytes(
                                                          new Regex("Sec-WebSocket-Key: (.*)").Match(data)
                                                              .Groups[1]
                                                              .Value.Trim() +
                                                          "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"))) + eol + eol);
            return response;
        }

        private void FixedUpdate()
        {
            if (_currentClientSocket == null)
            {
                return;
            }

            if (IsSocketConnected(_currentClientSocket))
            {
                return;
            }

            ResetSocket();
        }

        private void ResetSocket()
        {
            Debug.Log("AosSdk: web socket server restart: client lost");

            _serverSocket.Close();
            _serverSocket = null;
            _currentClientSocket.Close();
            _currentClientSocket = null;

            Init(_ipEndPoint);
        }

        private static bool IsSocketConnected(Socket socket) => !socket.Poll(1000, SelectMode.SelectRead) || socket.Available != 0;

        private void OnDisable()
        {
            _serverSocket.Close();
            OnClientMessageReceived -= ClientMessageReceived;
            OnClientMessageSent -= ClientMessageSent;
        }

        private void OnDestroy()
        {
            _serverSocket.Dispose();
            _serverSocket = null;
        }
    }
}