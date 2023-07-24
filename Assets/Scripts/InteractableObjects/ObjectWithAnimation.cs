using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithAnimation : BaseObject
{
    [SerializeField] private Collider _collider;
    private bool _open = false;
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (!_open)
        {
            _collider.enabled = false;
            _animator.SetTrigger("Open");
            _open = true;
        }
        else
        {
            _animator.SetTrigger("Close");
            _open = false;
            _collider.enabled = true;
        }

    }
}
