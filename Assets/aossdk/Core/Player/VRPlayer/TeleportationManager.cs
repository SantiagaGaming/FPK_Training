using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Player.VRPlayer
{
    public class TeleportationManager : MonoBehaviour
    {
        [SerializeField] private InputActionProperty teleportActivateAction;
        [SerializeField] private TeleportationManager anotherHandTeleportationManager;

        [SerializeField] private VRPlayer vrPlayer;
    
        [SerializeField] private GameObject teleportReticle;
        [SerializeField] private TeleportArcManager teleportArcManager;

        public bool IsTeleportActive { get; set; }

        private void OnEnable()
        {
            teleportActivateAction.action.performed += TeleportationActivateActionOnPerformed;
            teleportActivateAction.action.canceled += TeleportationActivateActionOnCancelled;
        }
    
        private void OnDisable()
        {
            teleportActivateAction.action.performed -= TeleportationActivateActionOnPerformed;
            teleportActivateAction.action.canceled -= TeleportationActivateActionOnCancelled;
        }
    
        private void TeleportationActivateActionOnPerformed(InputAction.CallbackContext obj)
        {
            if (anotherHandTeleportationManager.IsTeleportActive || !vrPlayer.CanMove)
            {
                return;
            }

            IsTeleportActive = true;
            teleportArcManager.ToggleDisplay(true);
            //Debug.Log("TeleportationActivateActionOnPerformed"); TODO remove
        }
    
        private void TeleportationActivateActionOnCancelled(InputAction.CallbackContext obj)
        {
            teleportArcManager.ToggleDisplay(false);
            
            if (!IsTeleportActive) // fix: snap turn cancel event triggers this method
            {
                return;
            }
            
            var teleportRaycastData = teleportArcManager.RaycastData;

            if (!teleportRaycastData.IsTeleportValid)
            {
                return;
            }
            
            if (teleportRaycastData.TeleportPosition == null || teleportRaycastData.TeleportNormal == null)
            {
                return;
            }

            vrPlayer.xrOrigin.MoveCameraToWorldLocation((Vector3) (teleportRaycastData.TeleportPosition + vrPlayer.xrOrigin.Origin.transform.up * vrPlayer.xrOrigin.CameraInOriginSpaceHeight));
        
            IsTeleportActive = false;
            
            //Debug.Log("TeleportationCancelActionOnPerformed"); TODO remove
        }
    
        private void LateUpdate()
        {
            if (IsTeleportActive)
            {
                var teleportRaycastData = teleportArcManager.RaycastData;

                if (teleportRaycastData.IsTeleportValid)
                {
                    teleportReticle.SetActive(true);

                    if (teleportRaycastData.TeleportPosition == null || teleportRaycastData.TeleportNormal == null)
                    {
                        return;
                    }

                    teleportReticle.transform.position = (Vector3) teleportRaycastData.TeleportPosition;
                    teleportReticle.transform.up = (Vector3) teleportRaycastData.TeleportNormal;
                    
                    return;
                }
            }
        
            teleportReticle.SetActive(false);
        }
    }
}
