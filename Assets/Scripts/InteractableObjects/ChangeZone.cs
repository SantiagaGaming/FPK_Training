using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeZone : BaseObject
{
    [SerializeField] protected GameObject KO;
    [SerializeField] protected GameObject VestibulWorking;

    [SerializeField] protected Animator Animator;

    public bool Open { get;set; } = false;

    public override void OnClicked(InteractHand interactHand)
    {
         
        if (!Open)
        {
            Open = true;
            VestibulWorking.SetActive(false);
            KO.SetActive(true);  
            Animator.SetTrigger("Open"); 
        }
        else 
        {
            Open = false;
            KO.SetActive(false);
            VestibulWorking.SetActive(true);
            Animator.SetTrigger("Close");
        }
        Debug.Log(Open.ToString() + " From Change zone");
    }



}
