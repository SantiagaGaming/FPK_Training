using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblerObject : BaseObject
{
    
    [SerializeField] private GameObject _screenPanel;
    [SerializeField] private LockEnabableObject _lockObject;

    private Animator _animator;
    private bool _tumblerOn = false;

    private void Start()
    {
        _animator= GetComponent<Animator>();
    }
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if(!_tumblerOn && _lockObject.CurrentState == "Idle" )
        {
            _animator.SetTrigger("OnAnim");
            _screenPanel.SetActive(false);
            _tumblerOn = true;

        }
        else if (!_tumblerOn && _lockObject.CurrentState == "Broken")
        {
            _animator.SetTrigger("OnAnim");
            _screenPanel.SetActive(true);
            _tumblerOn = true;
        }
        else
        {
            _animator.SetTrigger("OffAnim");
            _screenPanel.SetActive(true);
            _tumblerOn = false;
        }

    }
}
