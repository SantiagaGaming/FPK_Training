using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Input
{
    public class VRInput: SharedInput
    {
        [SerializeField] private InputActionProperty triggerAction;

        private void OnEnable()
        {
            triggerAction.action.canceled += TriggerActionCancelled;
        }
        
        private void OnDisable()
        {
            triggerAction.action.canceled -= TriggerActionCancelled;
        }
        
        private void TriggerActionCancelled(InputAction.CallbackContext obj)
        {
            StartCoroutine(PerformClick());
        }
    }
}