using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolkaObject : BaseObject
{
    [SerializeField] private Animator _animator;

    private bool _open = true;
    public override void OnClicked(InteractHand interactHand)
    { 
        if(_open)
        {
            _animator.SetTrigger("Close");
            _open= false;
        }
        else
        {
            _animator.SetTrigger("Open");
            _open = true;
        }
        
    }

}
