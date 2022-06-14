using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;

public class Door : BaseObject
{
    protected bool canAction = true;
    protected bool open = false;

    public override void OnClicked(InteractHand interactHand)
    {
        if (canAction)
            StartCoroutine(UseDoor(open));
    }
    protected virtual IEnumerator UseDoor(bool value)
    {
        yield return null;
    }
    protected void DoorAction(bool value)
    {
        if(value)
        {
            Player.Instance.CanMove = false;
            GetComponent<Collider>().isTrigger = true;
            canAction = false;
        }
        else
        {
            Player.Instance.CanMove = true;
            canAction = true;
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
