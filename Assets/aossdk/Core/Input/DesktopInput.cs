using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Input
{
    public class DesktopInput : SharedInput
    {
        [SerializeField] private InputActionProperty mouseLeftClickAction;
        [SerializeField] private InputActionProperty mouseRightClickAction;
        [SerializeField] private InputActionProperty wheelAction;

        private void OnEnable()
        {
            mouseLeftClickAction.action.canceled += OnLeftMouseUp;
            
            mouseRightClickAction.action.canceled += OnRightMouseUp;
            mouseRightClickAction.action.performed += OnRightMouseDown;

            wheelAction.action.performed += OnMouseWheel;
        }

        private void OnDisable()
        {
            mouseLeftClickAction.action.canceled -= OnLeftMouseUp;
            
            mouseRightClickAction.action.canceled -= OnRightMouseUp;
            mouseRightClickAction.action.performed -= OnRightMouseDown;

            wheelAction.action.performed -= OnMouseWheel;
        }

        private void OnLeftMouseUp(InputAction.CallbackContext obj)
        {
            StartCoroutine(PerformClick());
        }

        private void OnRightMouseDown(InputAction.CallbackContext obj)
        {
            StartCoroutine(PerformGrab());
        }

        private void OnRightMouseUp(InputAction.CallbackContext obj)
        {
            PerformUngrab();
        }

        private void OnMouseWheel(InputAction.CallbackContext obj)
        {
            StartCoroutine(PerformZoom(obj.ReadValue<float>()));
        }
    }
}