using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : BaseObject
{
    [SerializeField] private LockEnabableObject _lockObject;
    [SerializeField] private Animator[] _waterAnim;


    public override void OnClicked(InteractHand interactHand)
    {

        foreach (var anim in _waterAnim) 
        {
            anim.SetTrigger(_lockObject.CurrentState);
            Debug.Log(_lockObject.CurrentState + "In Button");
        }

    }
}
