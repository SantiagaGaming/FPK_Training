using AosSdk.Core.Input;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.PlayerModule.Pointer
{
    public class Pointer : MonoBehaviour
    {
        [SerializeField] protected RayCaster raycaster;

        internal PointerState CurrentState = PointerState.Unknown;

        internal static Color GetPointerColor(PointerState state)
        {
            var colorToSet = Launcher.Instance.SdkSettings.defaultPointerColor;

            switch (state)
            {
                case PointerState.Default:
                    colorToSet = Launcher.Instance.SdkSettings.defaultPointerColor;
                    break;
                case PointerState.Hovered:
                    colorToSet = Launcher.Instance.SdkSettings.hoveredPointerColor;
                    break;
                case PointerState.Disabled:
                    colorToSet = Launcher.Instance.SdkSettings.disabledPointerColor;
                    break;
                case PointerState.Unknown:
                default:
                    break;
            }

            return colorToSet;
        }
    }
}