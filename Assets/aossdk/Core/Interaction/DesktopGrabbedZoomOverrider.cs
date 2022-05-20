using AosSdk.Core.Interaction.Interfaces;
using UnityEngine;

namespace AosSdk.Core.Interaction
{
    [RequireComponent(typeof(IGrabbable))]
    public class DesktopGrabbedZoomOverrider : MonoBehaviour
    {
        [SerializeField] internal float minZoomDistance;
        [SerializeField] internal float maxZoomDistance;
    }
}