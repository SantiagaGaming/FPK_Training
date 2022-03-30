using AosSdk.Core.Input;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.Player.Pointer
{
    public class Pointer : MonoBehaviour
    {
        [SerializeField] protected AosSDKSettings sdkSettings;
        [SerializeField] protected RayCaster raycaster;
        
        internal PointerState CurrentState = PointerState.Unknown;

        internal Color GetPointerColor(PointerState state)
        {
            var colorToSet = sdkSettings.defaultPointerColor;

            switch (state)
            {
                case PointerState.Default:
                    colorToSet = sdkSettings.defaultPointerColor;
                    break;
                case PointerState.Hovered:
                    colorToSet = sdkSettings.hoveredPointerColor;
                    break;
                case PointerState.Disabled:
                    colorToSet = sdkSettings.disabledPointerColor;
                    break;
                case PointerState.Unknown:
                default:
                    break;
            }

            return colorToSet;
        }
    }
}