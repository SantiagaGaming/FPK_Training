using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Input
{
    public class DesktopInput: SharedInput
    {
        [SerializeField] private InputActionProperty mouseClickAction;

        private void OnEnable()
        {
            mouseClickAction.action.canceled += OnMouseUp;
        }
        
        private void OnDisable()
        {
            mouseClickAction.action.canceled -= OnMouseUp;
        }

        private void OnMouseUp(InputAction.CallbackContext obj)
        {
            StartCoroutine(PerformClick());
        }
    }
}