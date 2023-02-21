using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class BaseButton : BaseObject
{
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        base.OnHoverIn(interactHand);
        transform.localScale *= 1.5f;
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        base.OnHoverOut(interactHand);
        transform.localScale /= 1.5f;
    }
    public void DisableButton()
    {
        gameObject.SetActive(false);
    }
    public virtual void EnableButton(bool value)
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
            collider.enabled = value;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
            sprite.enabled = value;
    }
}