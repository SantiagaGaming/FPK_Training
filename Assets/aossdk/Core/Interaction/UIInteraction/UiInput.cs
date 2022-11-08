using AosSdk.Core.PlayerModule;
using UnityEngine;

namespace AosSdk.Core.Interaction.UIInteraction
{
    public class UiInput : MonoBehaviour
    {
        private void Start()
        {
            foreach (var canvas in FindObjectsOfType<Canvas>())
            {
                if (canvas.renderMode != RenderMode.WorldSpace)
                {
                    continue;
                }

                var interactableCanvas = canvas.gameObject.AddComponent<InteractableCanvas>();
                interactableCanvas.CanvasComponent.worldCamera = Player.Instance.EventCamera;
            }
        }
    }
}