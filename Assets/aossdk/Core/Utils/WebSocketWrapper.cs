using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    public class WebSocketWrapper : MonoBehaviour
    {
        [SerializeField] private AosCommandQueueHandler aosCommandQueueHandler;
        
        private AosSDKSettings _sdkSettings;

        public static WebSocketWrapper Instance;

        private Socket _serverSocket;
        private Socket _currentClientSocket;

        private readonly byte[] _buffer = new byte[1024];

        public delegate void SocketMessageReceivedHandler(string message);

        public delegate void SocketMessageSentHandler();

        public event SocketMessageReceivedHandler OnClientMessageReceived;
        public event SocketMessageSentHandler OnClientMessageSent;

        public void Init(IPAddress ip, int port, AosSDKSettings sdkSettings)
        {
            _sdkSettings = sdkSettings;
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, _sdkSettings.socketPort));
            _serverSocket.Listen(128);
            _serverSocket.BeginAccept(null, 0, ClientConnectedCallback, null);
            
            OnClientMessageReceived += ClientMessageReceived;
            OnClientMessageSent += ClientMessageSent;

            if (Instance == null)
            {
                Instance = this;
            }

            Debug.Log("AosSdk: web socket server is ready");
        }

        private static void ClientMessageSent()
        {
            Debug.Log($"AosSdk: Sent message to client.");
        }

        private void ClientMessageReceived(string message)
        {
            AosCommand aosCommandToQueue = null;
            try
            {
                aosCommandToQueue = JsonUtility.FromJson<AosCommand>(message);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
            finally
            {
                aosCommandQueueHandler.CommandQueue.Add(aosCommandToQueue);
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
                Console.WriteLine(e.ToString());
            }
        }

        private void ClientConnectedCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = null;

                if (_serverSocket is { IsBound: true })
                {
                    client = _serverSocket.EndAccept(ar);
                }

                if (client == null)
                {
                    return;
                }

                var messageLength = client.Receive(_buffer);

                if (messageLength == 0)
                {
                    return;
                }

                var headerResponse = Encoding.UTF8.GetString(_buffer).Substring(0, messageLength);

                var handshakeResponse = GetHandshakeData(headerResponse);

                if (handshakeResponse.Length == 0)
                {
                    return;
                }

                client.Send(handshakeResponse);

                _currentClientSocket = client;

                Debug.Log("AosSdk: web socket client connected");

                _currentClientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, MessageReceivedCallback,
                    _currentClientSocket);
            }
            catch (SocketException exception)
            {
                Debug.LogError(exception.ToString());
            }
            finally
            {
                if (_serverSocket is { IsBound: true })
                {
                    _serverSocket.BeginAccept(null, 0, ClientConnectedCallback, null);
                }
            }
        }

        private void MessageReceivedCallback(IAsyncResult result)
        {
            var client = result.AsyncState as Socket;

            try
            {
                if (client == null)
                {
                    return;
                }

                var received = client.EndReceive(result);

                var message = DecodeMessage(_buffer.Take(received).ToArray());

                OnClientMessageReceived?.Invoke(message);
            }
            catch (SocketException exception)
            {
                Debug.LogError(exception.ToString());
            }
            finally
            {
                client?.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, MessageReceivedCallback, client);
            }
        }

        private static string DecodeMessage(IReadOnlyList<byte> bytes)
        {
            var secondByte = bytes[1];
            var dataLength = secondByte & 127;
            var indexFirstMask = dataLength switch
            {
                126 => 4,
                127 => 10,
                _ => 2
            };

            var keys = bytes.Skip(indexFirstMask).Take(4);
            var indexFirstDataByte = indexFirstMask + 4;

            var decoded = new byte[bytes.Count - indexFirstDataByte];
            for (int i = indexFirstDataByte, j = 0; i < bytes.Count; i++, j++)
            {
                decoded[j] = (byte)(bytes[i] ^ keys.ElementAt(j % 4));
            }

            return Encoding.ASCII.GetString(decoded, 0, decoded.Length);
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
                frame[1] = (byte)length;
                indexStartRawData = 2;
            }
            else if (length <= 65535)
            {
                frame[1] = 126;
                frame[2] = (byte)((length >> 8) & 255);
                frame[3] = (byte)(length & 255);
                indexStartRawData = 4;
            }
            else
            {
                frame[1] = 127;
                frame[2] = (byte)((length >> 56) & 255);
                frame[3] = (byte)((length >> 48) & 255);
                frame[4] = (byte)((length >> 40) & 255);
                frame[5] = (byte)((length >> 32) & 255);
                frame[6] = (byte)((length >> 24) & 255);
                frame[7] = (byte)((length >> 16) & 255);
                frame[8] = (byte)((length >> 8) & 255);
                frame[9] = (byte)(length & 255);

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
            if (!new Regex("^GET").IsMatch(data)) return Array.Empty<byte>();
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

        private void OnDisable()
        {
            _serverSocket.Close();
            OnClientMessageReceived -= ClientMessageReceived;
            OnClientMessageSent -= ClientMessageSent;
        }
    }
}