using System.Collections;
using UnityEngine;

namespace AosSdk.Core.Input
{
    public enum PointerState
    {
        Default,
        Hovered,
        Unknown,
        Disabled
    }
    
    public class SharedInput : MonoBehaviour
    {
        public bool IsClicking { get; private set; }

        protected IEnumerator PerformClick()
        {
            IsClicking = true;
            yield return new WaitForEndOfFrame();
            IsClicking = !IsClicking;
        }
    }
}