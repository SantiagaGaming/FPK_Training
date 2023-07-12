using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationObject : BaseObject

{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public override void OnClicked(InteractHand interactHand)
    {
        _animator.SetTrigger("Idle");

    }
}
