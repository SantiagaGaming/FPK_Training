using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderObject : BaseObject
{
    [SerializeField] private LockEnabableObject _lockObject;
    [SerializeField] private Collider _polkaCollider;
    private Animator _animator;   
    private bool _open = false;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(BrokenStateLadder());
    }

    public override void OnClicked(InteractHand interactHand)
    {
        if (_lockObject.CurrentState == "Idle" && !_open)
        {
            _animator.SetTrigger("Open");
            _open= true;
            _polkaCollider.enabled= false;
        }
        else if (_lockObject.CurrentState == "Idle" && _open)
        {
            _animator.SetTrigger("Close");
            _open = false;
            _polkaCollider.enabled = true;
        }
        else if(_lockObject.CurrentState == "Broken" && !_open)
        {
            _animator.SetTrigger("Broken");
            _open = true;
            _polkaCollider.enabled = false;
            
        }
        else
        {
            _animator.SetTrigger("BrokenClose");
            _open = false;
            _polkaCollider.enabled = true;
           
        }

    }
    private IEnumerator BrokenStateLadder()
    {
        yield return new WaitForSeconds(2);
        if (_lockObject.CurrentState == "Broken")
        {
            _animator.SetTrigger("BrokenClose");
        }
    }
}
