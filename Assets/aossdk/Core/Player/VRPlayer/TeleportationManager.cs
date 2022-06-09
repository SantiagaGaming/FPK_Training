using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Interaction
{
    public class TeleportationManager : MonoBehaviour
    {
        [SerializeField] private InputActionProperty teleportActivateAction;

        [SerializeField] private GameObject teleportReticle;
        [SerializeField] protected TeleportArcManager teleportArcManager;

        public bool IsTeleportActive { get; set; }

        private void OnEnable()
        {
            teleportReticle.SetActive(false);
            
            teleportActivateAction.action.performed += TeleportationActivateActionOnPerformed;
            teleportActivateAction.action.canceled += TeleportationActivateActionOnCancelled;
        }

        private void OnDisable()
        {
            teleportActivateAction.action.performed -= TeleportationActivateActionOnPerformed;
            teleportActivateAction.action.canceled -= TeleportationActivateActionOnCancelled;
        }

        protected virtual void TeleportationActivateActionOnPerformed(InputAction.CallbackContext obj)
        {
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

            Player.Player.Instance.TeleportTo((Vector3) teleportRaycastData.TeleportPosition);
            
            IsTeleportActive = false;
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