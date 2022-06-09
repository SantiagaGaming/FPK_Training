using AosSdk.Core.Interaction;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Player.DesktopPlayer
{
    public class DesktopTeleportationManager : TeleportationManager
    {
        [SerializeField] private AosSDKSettings sdkSettings;

        protected override void TeleportationActivateActionOnPerformed(InputAction.CallbackContext obj)
        {
            if (!Player.Instance.CanMove)
            {
                return;
            }

            IsTeleportActive = true;
            teleportArcManager.ToggleDisplay(true);
        }

        private void Start()
        {
            teleportArcManager.transform.localPosition = sdkSettings.teleportArcOffset;

            if (sdkSettings.movementType != DesktopMovementType.Wasd)
            {
                return;
            }

            teleportArcManager.enabled = false;
            enabled = false;
        }
    }
}