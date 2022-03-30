using System.Collections.Generic;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    public class RuntimeData : MonoBehaviour
    {
        public static RuntimeData Instance { get; internal set; }

        public Player.Player CurrentPlayer { get; set; }
        public List<AosObjectBase> AosObjects { get; private set; } = new List<AosObjectBase>();

        private void OnEnable()
        {
            Instance ??= this;
        }
    }
}