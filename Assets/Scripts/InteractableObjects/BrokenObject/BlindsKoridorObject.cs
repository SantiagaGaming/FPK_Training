using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlindsKoridorObject : BaseObject
{
  

    private Animator _animator;
    
    [SerializeField] private LockEnabableObject _lockObject;
    private bool _open = true;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (_lockObject.CurrentState == "Idle" && _open)
        {
            _animator.SetTrigger("Idle");
            _open = false;

        }
        else if (_lockObject.CurrentState == "Idle" && !_open)
        {
            _animator.SetTrigger("Reverse");
            _open = true;
        }

        else
        {
            _animator.SetTrigger(_lockObject.CurrentState);
        }

    }

}
