using AosSdk.Core.Interaction;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Examples
{
    [AosObject("Пример грабабельного объекта")]
    public class GrabbableExample : AosObjectBase, IGrabbable, IClickAble
    {
        [field: SerializeField] public GrabType GrabType { get; set; }

        [field: SerializeField] public Transform GrabAnchor { get; set; }

        public bool IsGrabbable { get; set; } = true;
        public bool IsClickable { get; set; } = true;
        public bool IsGrabbed { get; set; }

        public void OnGrabbed(InteractHand interactHand)
        {
            Debug.Log("Grab started");
        }

        public void OnUnGrabbed(InteractHand interactHand)
        {
            Debug.Log("Grab ended");
        }

        public void OnClicked(InteractHand interactHand)
        {
            Debug.Log("Grabbed was clicked");
        }
    }
}