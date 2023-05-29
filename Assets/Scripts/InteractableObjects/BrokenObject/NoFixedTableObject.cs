using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFixedTableObject : BaseObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LockEnabableObject _lockObject;
    private bool _upPosition;
    
    public override void OnClicked(InteractHand interactHand)
    {
        if (_lockObject.CurrentState == "Idle" && _upPosition)
        {
            _animator.SetTrigger("Down");
            _upPosition = false;

        }
        else if (_lockObject.CurrentState == "Idle" && !_upPosition)
        {
            _animator.SetTrigger("Up");
            _upPosition = true;

        }


        else
        {
            _animator.SetTrigger(_lockObject.CurrentState);
        }

    }
 
}
