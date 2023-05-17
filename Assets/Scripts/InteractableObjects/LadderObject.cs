using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderObject : BaseObject
{
    private Animator _animator;
    [Space]
    private bool _open = false;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void OnClicked(InteractHand interactHand)
    {
        if (!_open)
        {
            _animator.SetTrigger("Open");
            _open= true;
        }
        else
        {
            _animator.SetTrigger("Close");
            _open = false;
        }

    }
}
