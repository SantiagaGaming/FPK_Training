using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationObject : BaseObject

{
    [SerializeField] private float _animTime;
    private Animator _animator;
    private bool _open = false;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (!_open)
        {
            GetComponent<Collider>().enabled = false;
            _animator.SetTrigger("Idle");
            StartCoroutine(Wait());
            _open= true;
        }
        else
        {
            GetComponent<Collider>().enabled = false;
            _animator.SetTrigger("Reverse");
            StartCoroutine(Wait());
            _open= false;
        }


    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_animTime);
        GetComponent<Collider>().enabled = true;

    }
}
