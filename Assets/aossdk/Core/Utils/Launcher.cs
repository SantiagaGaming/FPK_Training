using System;
using System.Net;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private AosSDKSettings sdkSettings;
        [SerializeField] private WebSocketWrapper webSocketWrapper;
        [SerializeField] private Player.Player player;

        private string _webSocketIpAddress = "127.0.0.1";
        private int _webSocketPort = 8080;
        private string _aosPendingSecret = string.Empty;

        private const string AosSecret = "aos";

        private void OnEnable()
        {
            var commandLineArguments = Environment.GetCommandLineArgs();

            if (!Application.isEditor)
            {
                foreach (var argument in commandLineArguments)
                {
                    var argumentType = argument.Substring(0, 2);
                    switch (argumentType)
                    {
                        case "-i":
                            _webSocketIpAddress = argument.Substring(2);
                            break;
                        case "-p":
                            _webSocketPort = int.Parse(argument.Substring(2));
                            break;
                        case "-s":
                            _aosPendingSecret = argument.Substring(2);
                            break;
                        case "-m":
                            sdkSettings.launchMode = argument.Substring(2).Contains(LaunchMode.Desktop.ToString()) ? LaunchMode.Desktop : LaunchMode.Vr;
                            break;
                    }
                }
            }
            else
            {
                _aosPendingSecret = AosSecret;
            }

            if (_aosPendingSecret != AosSecret)
            {
                Debug.LogError("Wrong secret key, quiting...");
                Application.Quit();
            }

            Debug.Log($"Launched in {sdkSettings.launchMode.ToString()} mode");

            webSocketWrapper.Init(IPAddress.Parse(_webSocketIpAddress), _webSocketPort, sdkSettings);
            
            player.LaunchMode = sdkSettings.launchMode;
            
            RuntimeData.Instance.AosObjects.AddRange(FindObjectsOfType<AosObjectBase>());
        }
    }
}