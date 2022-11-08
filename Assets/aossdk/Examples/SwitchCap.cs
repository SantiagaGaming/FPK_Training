using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;

namespace AosSdk.Examples
{
    public class SwitchCap : MonoBehaviour, IClickAble, IHoverAble
    {
        public delegate void CapEventHandler();

        public event CapEventHandler OnCapOpened;
    
        public void OnClicked(InteractHand interactHand)
        {
            OnCapOpened?.Invoke();
        }

        public void OnHoverIn(InteractHand interactHand)
        {
            GetComponent<Renderer>().material.color /= 2;
        }

        public void OnHoverOut(InteractHand interactHand)
        {
            GetComponent<Renderer>().material.color *= 2;
        }

        public bool IsHoverable { get; set; } = true;
        
        public bool IsClickable { get; set; }  = true;
    }
}