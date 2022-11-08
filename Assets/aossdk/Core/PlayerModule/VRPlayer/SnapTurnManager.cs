using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.PlayerModule.VRPlayer
{
    public class SnapTurnManager : MonoBehaviour
    {
        [SerializeField] private InputActionProperty snapTurnAction;
        [SerializeField] private XROrigin xrOrigin;
        
        [SerializeField] private float snapTurnDelta;

        private void OnEnable()
        {
            snapTurnAction.action.Enable();
            snapTurnAction.action.performed += SnapTurnActionOnPerformed;
        }

        private void OnDisable()
        {
            snapTurnAction.action.Disable();
            snapTurnAction.action.performed -= SnapTurnActionOnPerformed;
        }
        
        private void SnapTurnActionOnPerformed(InputAction.CallbackContext obj)
        {
            var input = snapTurnAction.action.ReadValue<Vector2>();

            xrOrigin.RotateAroundCameraUsingOriginUp(snapTurnDelta * (input.x > 0 ? 1 : -1));
        }
    }
}