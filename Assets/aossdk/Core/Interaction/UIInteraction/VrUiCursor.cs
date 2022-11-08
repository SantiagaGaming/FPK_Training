using System.Collections.Generic;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace AosSdk.Core.Interaction.UIInteraction
{
    public class VrUiCursor : UiCursor
    {
        [SerializeField] private InputActionReference _triggerAction;
        private bool _isOverInteractableCanvas;

        private Vector3 CurrentHitPosition { get; set; }

        private Transform _thisTransform;

        private bool _isMouseDown;

        private bool _previousMouseLeftButtonState;

        private void Start()
        {
            _thisTransform = transform;
        }

        protected override void UpdateMouseState()
        {
            if (VirtualMouse == null || !_isOverInteractableCanvas)
            {
                return;
            }

            InputState.Change(VirtualMouse.position, Player.Instance.EventCamera.WorldToScreenPoint(CurrentHitPosition));

            VirtualMouse.CopyState<MouseState>(out var mouseState);

            mouseState = mouseState.WithButton(MouseButton.Left, _triggerAction.action.ReadValue<float>() > .5f);
            InputState.Change(VirtualMouse, mouseState);
        }

        private void LateUpdate()
        {
            GetCurrentHitPosition();
        }

        private void GetCurrentHitPosition()
        {
            var hits = new RaycastHit[1];
            var hitCount = Physics.RaycastNonAlloc(transform.position, transform.TransformDirection(Vector3.forward), hits, Launcher.Instance.SdkSettings.vrInteractDistance,
                ~LayerMask.NameToLayer("UI"));

            if (hitCount == 0)
            {
                _isOverInteractableCanvas = false;
                return;
            }

            if (!GetValidHit(hits, out var candidateHit))
            {
                _isOverInteractableCanvas = false;
                return;
            }

            _isOverInteractableCanvas = true;

            CurrentHitPosition = candidateHit.point;

            Debug.DrawLine(_thisTransform.position, CurrentHitPosition, Color.red);
        }

        private static bool GetValidHit(IEnumerable<RaycastHit> hits, out RaycastHit validHit)
        {
            foreach (var hit in hits)
            {
                if (!hit.collider.gameObject.GetComponent<InteractableCanvas>())
                {
                    continue;
                }

                validHit = hit;
                return true;
            }

            validHit = new RaycastHit();
            return false;
        }
    }
}