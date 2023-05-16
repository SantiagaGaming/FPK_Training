using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObject : BaseObject
{
    [SerializeField] private LockEnabableObject _lockObject;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }
    public override void OnClicked(InteractHand interactHand)
    {
        
        _animator.SetTrigger(_lockObject.CurrentState);
       
    }
}
