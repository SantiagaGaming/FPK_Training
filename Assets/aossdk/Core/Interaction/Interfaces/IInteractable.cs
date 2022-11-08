using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;

namespace AosSdk.Core.Interaction.Interfaces
{
    public interface IClickAble : IInteractable
    {
        public void OnClicked(InteractHand interactHand);
        public bool IsClickable { get; set; }
    }

    public interface IHoverAble : IInteractable
    {
        public void OnHoverIn(InteractHand interactHand);
        public void OnHoverOut(InteractHand interactHand);

        public bool IsHoverable { get; set; }
    }

    public interface IGrabbable : IInteractable
    {
        public bool IsGrabbable { get; set; }
        public bool IsGrabbed { get; set; }
        public GrabType GrabType { get; set; }

        public Transform GrabAnchor { get; set; }

        public void OnGrabbed(InteractHand interactHand);
        public void OnUnGrabbed(InteractHand interactHand);
    }

    public interface IInteractable
    {
    }
}