using System.Collections;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Interaction
{
    public class MovementManager : MonoBehaviour
    {
        [field: SerializeField] protected InputActionProperty TeleportActivateAction { get; private set; }

        [SerializeField] private GameObject teleportReticle;
        [SerializeField] protected TeleportArcManager teleportArcManager;

        public bool IsMovementInProgress { get; set; }

        private void OnEnable()
        {
            teleportReticle.SetActive(false);

            StartCoroutine(SubscribeToActions());
        }

        private IEnumerator SubscribeToActions()
        {
            yield return new WaitWhile(() => Launcher.Instance == null);

            if (IsVRLocomotion())
            {
                yield break;
            }

            TeleportActivateAction.action.performed += TeleportationActivateActionOnPerformed;
            TeleportActivateAction.action.canceled += TeleportationActivateActionOnCancelled;
        }

        private void OnDisable()
        {
            if (IsVRLocomotion())
            {
                return;
            }

            TeleportActivateAction.action.performed -= TeleportationActivateActionOnPerformed;
            TeleportActivateAction.action.canceled -= TeleportationActivateActionOnCancelled;
        }

        protected virtual void TeleportationActivateActionOnPerformed(InputAction.CallbackContext obj)
        {
        }

        private void TeleportationActivateActionOnCancelled(InputAction.CallbackContext obj)
        {
            teleportArcManager.ToggleDisplay(false);

            if (!IsMovementInProgress) // fix: snap turn cancel event triggers this method
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

            PlayerModule.Player.Instance.TeleportTo((Vector3) teleportRaycastData.TeleportPosition);

            IsMovementInProgress = false;
        }

        private void LateUpdate()
        {
            if (IsVRLocomotion())
            {
                return;
            }

            if (IsMovementInProgress)
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

        protected static bool IsVRLocomotion()
        {
            var settings = Launcher.Instance.SdkSettings;
            return settings.launchMode == LaunchMode.Vr && settings.vrMovementType == VrMovementType.Locomotion;
        }
    }
}