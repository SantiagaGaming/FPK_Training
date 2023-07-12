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
        GetComponent<Collider>().enabled= false;
        _animator.SetTrigger("Idle");
        StartCoroutine(Wait());


    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Collider>().enabled = true;

    }
}
