using System.Collections.Generic;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    public enum LaunchMode
    {
        Desktop,
        Vr
    }
    
    [CreateAssetMenu(fileName = "AosSDKSettings", menuName = "AOS/AosSDKSettings", order = 1)]
    public class AosSDKSettings : ScriptableObject
    {
        [Header("Unity Debug")]
        [SerializeField] internal LaunchMode launchMode = LaunchMode.Desktop;
        
        [Space] 
        
        [Header("Connection")]
        [SerializeField] internal int socketPort = 8080;

        [Space] 
        
        [Header("Desktop player move")]
        [SerializeField] internal float walkSpeed = 4f;
        [SerializeField] internal float runSpeed = 8f;
        [SerializeField] internal float jumpSpeed = 8f;
        [SerializeField] internal float gravity = 20f;
        [SerializeField] internal float mouseLookSpeed = 0.5f;
        [SerializeField] internal float mouseLookXLimit = 45f;
        
        [Header("Desktop player interaction")]
        [SerializeField] internal float crossHairSizeMultiplier = 1f;
        [SerializeField] internal float desktopInteractDistance = 0.6f;
        
        [Space]
        
        [Header("VR player")]
        [SerializeField] internal float maxTeleportRadius = 8f;
        [SerializeField] internal float vrInteractDistance = 0.6f;
        
        [Space]
        [Header("Common")]
        [SerializeField] internal Color defaultPointerColor = Color.white;
        [SerializeField] internal Color hoveredPointerColor = new Color(14, 161, 200, 255);
        [SerializeField] internal Color disabledPointerColor = Color.red;
        [SerializeField] internal string walkableTag = "Walkable";
    }
}