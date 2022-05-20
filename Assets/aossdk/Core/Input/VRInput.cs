using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Input
{
    public class VRInput : SharedInput
    {
        [SerializeField] private InputActionProperty triggerAction;
        [SerializeField] private InputActionProperty gripAction;

        private void OnEnable()
        {
            triggerAction.action.canceled += TriggerActionCancelled;

            gripAction.action.performed += GripPressed;
            gripAction.action.canceled += GripReleased;
        }

        private void OnDisable()
        {
            triggerAction.action.canceled -= TriggerActionCancelled;

            gripAction.action.performed -= GripPressed;
            gripAction.action.canceled -= GripReleased;
        }

        private void TriggerActionCancelled(InputAction.CallbackContext obj)
        {
            StartCoroutine(PerformClick());
        }

        private void GripPressed(InputAction.CallbackContext obj)
        {
            StartCoroutine(PerformGrab());
        }

        private void GripReleased(InputAction.CallbackContext obj)
        {
            PerformUngrab();
        }
    }
}