using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Interaction.UIInteraction
{
    public class UiCursor : MonoBehaviour
    {
        protected Mouse VirtualMouse;

        private void OnEnable()
        {
            if (VirtualMouse == null)
            {
                VirtualMouse = (Mouse) InputSystem.AddDevice("VirtualMouse");
            }
            else if (!VirtualMouse.added)
            {
                InputSystem.AddDevice(VirtualMouse);
            }

            InputSystem.onAfterUpdate += UpdateMouseState;
        }

        private void OnDisable()
        {
            InputSystem.onAfterUpdate -= UpdateMouseState;
            InputSystem.RemoveDevice(VirtualMouse);
        }

        protected virtual void UpdateMouseState()
        {
        }
    }
}