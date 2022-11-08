using System;

namespace AosSdk.Core.Utils.EditorUtils
{
    public class BuildInfo
    {
        public string BuildDate;
        public int BuildNumber;
        public string BuildFingerPrint;
        public const string SdkVersionInfoPath = "Assets/aossdk/buildinfo";
    }
}