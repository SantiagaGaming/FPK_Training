using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;
using AosSdk.Core.PlayerModule.Pointer;

public class BaseObject : MonoBehaviour, IClickAble, IHoverAble
{
    public bool IsHoverable { get; set; } = true;
    public bool IsClickable { get; set; } = true;

    [SerializeField] protected OutlineCore[] outlineObjects;
    public virtual void OnClicked(InteractHand interactHand)
    {
    }
    public virtual void OnHoverIn(InteractHand interactHand)
    {
        EnableOutlines(true);
    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {
        EnableOutlines(false);
    }
    protected void EnableOutlines(bool value)
    {
        if (outlineObjects != null)
            foreach (var outline in outlineObjects)
            {
                
                if (outline.GetComponent<MeshRenderer>() == null)
                {
                    return;
                }

                if (value)
                {
                    outline.GetComponent<MeshRenderer>().material.color *= 2f;
                }

                else
                {
                    outline.GetComponent<MeshRenderer>().material.color /= 2f;
                }

            }
    }
}