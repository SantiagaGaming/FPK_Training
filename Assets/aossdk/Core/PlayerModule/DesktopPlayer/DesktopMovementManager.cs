using AosSdk.Core.Interaction;
using AosSdk.Core.Utils;
using UnityEngine.InputSystem;

namespace AosSdk.Core.PlayerModule.DesktopPlayer
{
    public class DesktopMovementManager : MovementManager
    {
        protected override void TeleportationActivateActionOnPerformed(InputAction.CallbackContext obj)
        {
            if (!Player.Instance.CanMove)
            {
                return;
            }

            IsMovementInProgress = true;
            teleportArcManager.ToggleDisplay(true);
        }

        private void Start()
        {
            teleportArcManager.transform.localPosition = Launcher.Instance.SdkSettings.teleportArcOffset;

            if (Launcher.Instance.SdkSettings.desktopMovementType != DesktopMovementType.Wasd)
            {
                return;
            }

            teleportArcManager.enabled = false;
            enabled = false;
        }
    }
}