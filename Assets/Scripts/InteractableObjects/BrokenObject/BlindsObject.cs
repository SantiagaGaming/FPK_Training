using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindsObject : BaseObject
{
    [SerializeField] private LockEnabableObject _lockObject;
    private Animator _animator;
    private bool _open = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (_lockObject.CurrentState == "Idle" && _open)
        {
            _animator.SetTrigger(_lockObject.CurrentState);
            _open= false;

        }
        else if (_lockObject.CurrentState == "Idle" && !_open)
        {
            _animator.SetTrigger("Reverse");
            _open = true;
            Debug.Log("In");
        }


        else
        {
            _animator.SetTrigger(_lockObject.CurrentState);
        }

    }

}
