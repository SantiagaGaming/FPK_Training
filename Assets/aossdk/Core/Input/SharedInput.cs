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
        public bool IsGrabbing { get; private set; }
        public bool IsHoldingGrab { get; private set; }

        public float ZoomValue { get; private set; }

        protected IEnumerator PerformClick()
        {
            IsClicking = true;
            yield return new WaitForEndOfFrame();
            IsClicking = false;
        }

        protected IEnumerator PerformGrab()
        {
            IsGrabbing = true;
            yield return new WaitForEndOfFrame();
            IsHoldingGrab = true;
            IsGrabbing = false;
        }

        protected void PerformUngrab()
        {
            IsHoldingGrab = false;
        }

        protected IEnumerator PerformZoom(float value)
        {
            ZoomValue = value < 0 ? -1 : 1;
            yield return new WaitForEndOfFrame();
            ZoomValue = 0;
        }
    }
}