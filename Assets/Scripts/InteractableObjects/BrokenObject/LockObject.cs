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
            _door.locked = true;
            
        }
        else if (_lockObject.CurrentState == "Idle" && !_open)
        {
            _animator.SetTrigger("Reverse");
            _open = true;
            _door.locked = false;
        }
        else
        {
            _animator.SetTrigger(_lockObject.CurrentState);
        }
        
       
    }
}
