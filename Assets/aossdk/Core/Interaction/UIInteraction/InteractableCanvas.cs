using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;

namespace AosSdk.Core.Interaction.UIInteraction
{
    [RequireComponent(typeof(Canvas))]
    [DisallowMultipleComponent]
    public class InteractableCanvas : MonoBehaviour, IHoverAble
    {
        public Canvas CanvasComponent { get; private set; }

        private void OnEnable()
        {
            CanvasComponent = GetComponent<Canvas>();
            var col = gameObject.AddComponent<BoxCollider>();
            col.isTrigger = true;

            var sizeDelta = ((RectTransform) transform).sizeDelta;

            col.size = new Vector3(sizeDelta.x, sizeDelta.y, 0f);
        }

        public void OnHoverIn(InteractHand interactHand)
        {
        }

        public void OnHoverOut(InteractHand interactHand)
        {
        }

        public bool IsHoverable { get; set; } = true;
    }
}