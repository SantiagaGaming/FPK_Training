using AosSdk.Core.Input;
using UnityEngine;
using UnityEngine.UI;

namespace AosSdk.Core.Player.Pointer
{
    [RequireComponent(typeof(Image))]
    public class DesktopPointer : Pointer
    {
        private Image _crossHairImage;

        private PointerState PointerState
        {
            set
            {
                if (value == CurrentState)
                {
                    return;
                }

                _crossHairImage.color = GetPointerColor(value);
                CurrentState = value;
            }
        }

        private void Awake()
        {
            _crossHairImage = GetComponent<Image>();

            CrossHairSizeMultiplier = sdkSettings.crossHairSizeMultiplier;
        }

        private float CrossHairSizeMultiplier
        {
            set
            {
                var size = (float) Screen.width * 1 / 100 * value;
                _crossHairImage.rectTransform.sizeDelta = new Vector2(size, size);
            }
        }

        private void Update()
        {
            if (!raycaster.TryGetInteractable(sdkSettings.desktopInteractDistance, out _, out _, out var isInteractable))
            {
                PointerState = PointerState.Default;
                return;
            }

            if (isInteractable == null)
            {
                PointerState = PointerState.Default;
                return;
            }

            PointerState = (bool) isInteractable ? PointerState.Hovered : PointerState.Disabled;
        }
    }
}