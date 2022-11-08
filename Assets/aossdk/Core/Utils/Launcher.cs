using System;
using System.IO;
using System.Net;
using System.Text;
using AosSdk.Core.Utils.EditorUtils;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    [RequireComponent(typeof(WebSocketWrapper))]
    public class Launcher : MonoBehaviour
    {
        [field: SerializeField] public AosSDKSettings SdkSettings { get; private set; }
        [SerializeField] private PlayerModule.Player player;

        private string _webSocketIpAddress = "127.0.0.1";
        private int _webSocketPort = 8080;
        private string _aosPendingSecret = string.Empty;

        private WebSocketWrapper _webSocketWrapper;

        private const string AosSecret = "aos";

        internal static Launcher Instance { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);

            Instance ??= this;

            _webSocketWrapper = GetComponent<WebSocketWrapper>();

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
                            SdkSettings.launchMode = argument.Substring(2).Contains(LaunchMode.Desktop.ToString()) ? LaunchMode.Desktop : LaunchMode.Vr;
                            break;
                    }
                }
            }
            else
            {
                _webSocketPort = SdkSettings.socketPort;
                _aosPendingSecret = AosSecret;
            }
#if UNITY_STANDALONE_WIN
            if (_aosPendingSecret != AosSecret)
            {
                Debug.LogError("Wrong secret key, quiting...");
                Application.Quit();
            }
#endif
#if UNITY_ANDROID
            sdkSettings.launchMode = LaunchMode.Vr;
#endif
            GetBuildInfo(out var buildDate, out var buildNumber, out var buildFingerprint);
            Debug.Log($"AOS SDK Build number:{buildNumber} ({buildFingerprint}), build at:{buildDate}");

            Debug.Log($"Launched in {SdkSettings.launchMode.ToString()} mode");

            _webSocketWrapper.Init(new IPEndPoint(IPAddress.Parse(_webSocketIpAddress), _webSocketPort));

            player.LaunchMode = SdkSettings.launchMode;
        }

        private static void GetBuildInfo(out string buildDate, out int buildNumber, out string buildFingerprint)
        {
            const string sdkInfoPath = BuildInfo.SdkVersionInfoPath;

            if (File.Exists(sdkInfoPath))
            {
                var buildInfo = File.ReadAllBytes(sdkInfoPath);
                var buildInfoJson = Encoding.UTF8.GetString(buildInfo, 0, buildInfo.Length);

                var buildInfoObject = JsonUtility.FromJson<BuildInfo>(buildInfoJson);
                buildDate = buildInfoObject.BuildDate;
                buildNumber = buildInfoObject.BuildNumber;
                buildFingerprint = buildInfoObject.BuildFingerPrint;
            }
            else
            {
                buildDate = "Unknown build date";
                buildNumber = -1;
                buildFingerprint = "Unknown build fingerprint";
            }
        }
    }
}