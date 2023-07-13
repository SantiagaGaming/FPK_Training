using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.PlayerModule;

public class Door : BaseObject
{
    [SerializeField] protected GameObject handle;
   
    protected bool canAction = true;
    public bool open = false;
    public bool LockedSecretKey = false;
    public bool LockedSpecKey = false;
    


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
    public virtual void UseDoorByCollide(bool value)
    {
        StartCoroutine(UseDoor(value));
    }
}
