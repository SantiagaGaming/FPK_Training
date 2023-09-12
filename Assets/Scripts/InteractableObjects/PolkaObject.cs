using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolkaObject : BaseObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _ladderCollider;
    [SerializeField] private LockEnabableObject _lockObject;

    private bool _open = true;

    private void Start()
    {
        StartCoroutine(BrokenPolka());
    }
    public override void OnClicked(InteractHand interactHand)
    { 
        if(_lockObject.CurrentState == "Idle" && _open)
        {
            _ladderCollider.enabled = true;
            _animator.SetTrigger("Close");
            _open= false;
        }
        else if (_lockObject.CurrentState == "Idle" && !_open)
        {
            _ladderCollider.enabled = false;
            _animator.SetTrigger("Open");
            _open = true;
        }
        else
        {
            _animator.SetTrigger(_lockObject.CurrentState);
        }
    }
    private IEnumerator BrokenPolka()
    {
        Debug.Log("THIS  1");
        yield return new WaitForSeconds(4);
        if (_lockObject.CurrentState == "Broken")
        {
            _ladderCollider.enabled = true;
            _animator.SetTrigger("Close");
            Debug.Log("THIS  2");
            
        }
    }
}
