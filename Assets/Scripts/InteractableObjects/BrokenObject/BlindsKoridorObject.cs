using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlindsKoridorObject : BaseObject
{
  

    private Animator _animator;
    public string BrokenBlinds { get; set; } = "Idle";
    private bool _open = true;
   

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (BrokenBlinds == "Idle" && _open)
        {
            _animator.SetTrigger("Idle");
            _open = false;

        }
        else if (BrokenBlinds == "Idle" && !_open)
        {
            _animator.SetTrigger("Reverse");
            _open = true;
        }

        else
        {
            _animator.SetTrigger(BrokenBlinds);
        }

    }

}
