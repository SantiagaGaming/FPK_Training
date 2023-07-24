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
    [SerializeField] private Animator _keyAnim;

    public bool Open { get; set; } = false;

    public override void OnClicked(InteractHand interactHand)
    {

        if (!Open)
        {
            StartCoroutine(PlayOpenKeyAnim());
        }
        else
        {
            StartCoroutine(PlayCloseKeyAnim());
        }

    }
    private IEnumerator PlayOpenKeyAnim()
    {
        _keyAnim.SetTrigger("Open");
        Open = true;
        VestibulWorking.SetActive(false);
        KO.SetActive(true);
        yield return new WaitForSeconds(2.1f);
        Animator.SetTrigger("Open");
    }
    private IEnumerator PlayCloseKeyAnim()
    {
        Open = false;
        KO.SetActive(false);
        VestibulWorking.SetActive(true);
        Animator.SetTrigger("Close");
        yield return new WaitForSeconds(1.8f);
        _keyAnim.SetTrigger("Close");

    }

}
