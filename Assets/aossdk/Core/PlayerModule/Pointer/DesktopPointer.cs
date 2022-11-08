using AosSdk.Core.Input;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AosSdk.Core.PlayerModule.Pointer
{
    [RequireComponent(typeof(Image))]
    public class DesktopPointer : Pointer
    {
        public Canvas Canvas { get; private set; }
        public RectTransform CanvasRectTransform { get; private set; }
        public RectTransform RectTransform { get; private set; }

        private Image _image;

        private int _screenWidth;

        private PointerState PointerState
        {
            set
            {
                if (value == CurrentState)
                {
                    return;
                }

                _image.color = GetPointerColor(value);
                CurrentState = value;
            }
        }

        private void Start()
        {
            Canvas = GetComponentInParent<Canvas>();
            CanvasRectTransform = (RectTransform) Canvas.gameObject.transform;
            RectTransform = (RectTransform) transform;
            _image = GetComponent<Image>();

            _screenWidth = Screen.width;

            UpdateCrossHairSize();
        }

        private void UpdateCrossHairSize()
        {
            var size = (float) _screenWidth / 100 * Launcher.Instance.SdkSettings.crossHairSizeMultiplier;
            _image.rectTransform.sizeDelta = new Vector2(size, size);
        }

        private void FixedUpdate()
        {
            if (Screen.width == _screenWidth)
            {
                return;
            }

            _screenWidth = Screen.width;

            UpdateCrossHairSize();
        }

        private void Update()
        {
            if (!raycaster.TryGetInteractable(Launcher.Instance.SdkSettings.desktopInteractDistance, out _, out _, out var isInteractable) ||
                isInteractable == null)
            {
                PointerState = PointerState.Default;
                return;
            }

            PointerState = (bool) isInteractable ? PointerState.Hovered : PointerState.Disabled;
        }
    }
}