using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace AosSdk.Core.Interaction.UIInteraction
{
    public class DesktopUiCrossHairCursor : UiCursor
    {
        [SerializeField] private DesktopPointer _desktopPointer;

        protected override void UpdateMouseState()
        {
            if (VirtualMouse == null)
            {
                return;
            }

            var mousePosition = Player.Instance.CursorLockMode == CursorLockMode.Locked
                ? Mouse.current.position.ReadValue()
                : new Vector2(Player.Instance.EventCamera.pixelWidth / 2f, Player.Instance.EventCamera.pixelHeight / 2f);

            InputState.Change(VirtualMouse.position, mousePosition);

            VirtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, Mouse.current.leftButton.isPressed);
            InputState.Change(VirtualMouse, mouseState);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_desktopPointer.CanvasRectTransform, mousePosition,
                _desktopPointer.Canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Player.Instance.EventCamera, out var point);

            _desktopPointer.RectTransform.anchoredPosition = point;
        }
    }
}