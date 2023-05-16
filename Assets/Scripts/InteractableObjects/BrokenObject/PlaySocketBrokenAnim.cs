using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlaySocketBrokenAnim : SearchableObject
{
    [SerializeField] private Animator _animator;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if(!value)
        {
            _animator.SetTrigger("Broken");
        }
        
    }
}

