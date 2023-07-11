using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObject : BaseObject
{
    [SerializeField] private LockEnabableObject _lockObject;
    [SerializeField] private Door _door;
    private Animator _animator;
    private bool _open = true;
    public bool SpecKey = false;
    public bool SecretKey = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }
    public override void OnClicked(InteractHand interactHand)
    {
        if(_lockObject.CurrentState =="Idle" && _open)
        {
            _animator.SetTrigger(_lockObject.CurrentState);
            _open= false;
            if(SecretKey)
            {
                _door.LockedSecretKey = true;
            }           
            if (SpecKey)
            {
                _door.LockedSpecKey = true;
            }
            
        }
        else if (_lockObject.CurrentState == "Idle" && !_open)
        {
            _animator.SetTrigger("Reverse");
            _open = true;

            if (SecretKey)
            {
                _door.LockedSecretKey = false;
            }
            if (SpecKey)
            {
                _door.LockedSpecKey = false;
            }

        }
        else
        {
            _animator.SetTrigger(_lockObject.CurrentState);
        }
        
       
    }
}
