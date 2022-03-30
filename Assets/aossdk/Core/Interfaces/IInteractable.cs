using AosSdk.Core.Player.Pointer;

namespace AosSdk.Core.Interfaces
{
    public interface IClickAble : IInteractable
    {
        void OnClicked(InteractHand interactHand);
        public bool IsClickable { get; set; }
    }

    public interface IHoverAble : IInteractable
    {
        void OnHoverIn(InteractHand interactHand);
        void OnHoverOut(InteractHand interactHand);

        public bool IsHoverable { get; set; }
    }

    public interface IInteractable
    {
    }
}