using UnityEngine;
using UnityEngine.Serialization;

namespace AosSdk.Core.Utils
{
    public enum LaunchMode
    {
        Desktop,
        Vr
    }
    
    public enum DesktopMovementType 
    {
        Wasd,
        Teleport,
        Both
    }

    [CreateAssetMenu(fileName = "AosSDKSettings", menuName = "AOS/AosSDKSettings", order = 1)]
    public class AosSDKSettings : ScriptableObject
    {
        [Header("Unity Debug")] [SerializeField]
        internal LaunchMode launchMode = LaunchMode.Desktop;

        [Space] [Header("Connection")] [SerializeField]
        internal int socketPort = 8080;

        [Space] [Header("Desktop player move")] [SerializeField]
        internal DesktopMovementType movementType = DesktopMovementType.Teleport;

        [SerializeField] internal Vector3 teleportArcOffset;
        [SerializeField] internal float walkSpeed = 4f;
        [SerializeField] internal float runSpeed = 8f;
        [SerializeField] internal float jumpSpeed = 8f;
        [SerializeField] internal float gravity = 20f;

        [Header("Desktop player look")] [SerializeField]
        internal float mouseLookSpeed = 0.5f;

        [SerializeField] internal float mouseLookXLimit = 45f;

        [Header("Desktop player interaction")] [SerializeField]
        internal float crossHairSizeMultiplier = 1f;

        [Space] [Header("Interaction")] [SerializeField]
        internal float vrInteractDistance = 0.6f;

        [SerializeField] internal float desktopInteractDistance = 0.6f;
        [SerializeField] internal float desktopGrabMinZoomDistance = 0.2f;
        [SerializeField] internal float desktopGrabMaxZoomDistance = 2f;
        [SerializeField] internal bool hideHandOnGrab = true;

        [Space] [Header("Common")] [SerializeField]
        internal Color defaultPointerColor = Color.white;

        [SerializeField] internal Color hoveredPointerColor = new Color(14, 161, 200, 255);
        [SerializeField] internal Color disabledPointerColor = Color.red;
        [SerializeField] internal string walkableTag = "Walkable";
        [SerializeField] internal float maxTeleportRadius = 8f;
    }
}