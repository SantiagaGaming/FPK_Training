using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KranObject : BaseObject
{
    [SerializeField] private LockEnabableObject _lockObject;
    [SerializeField] private Animator _animator;
    public override void OnClicked(InteractHand interactHand)
    {
       if(_lockObject.CurrentState == "Idle")
        {
            _animator.SetTrigger("Idle");
        }
        else
        {
            _animator.SetTrigger(_lockObject.CurrentState);
        }
    }
}
