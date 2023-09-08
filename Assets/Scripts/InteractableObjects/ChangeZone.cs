using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeZone : BaseObject
{
    [SerializeField] protected GameObject KO;
    [SerializeField] protected GameObject VestibulWorking;
    [SerializeField] protected Collider _collider;
    [SerializeField] protected Collider[] _colliderDoor;

    [SerializeField] protected Animator Animator;
    [SerializeField] private Animator _keyAnim;

    public bool Open { get; set; } = false;
    private void Start()
    {

    }

    public override void OnClicked(InteractHand interactHand)
    {

        if (!Open)
        {
            if (_collider != null) { _collider.enabled = false; }
            StartCoroutine(PlayOpenKeyAnim());
        }
        else
        {
            if (_collider != null) { _collider.enabled = false; }
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
        yield return new WaitForSeconds(1.5f);
        if (_colliderDoor != null)
        {
            foreach (var item in _colliderDoor)
            {
                item.enabled = true;
            }
        }
        if (_collider != null) { _collider.enabled = true; }


    }
    private IEnumerator PlayCloseKeyAnim()
    {
        if (_colliderDoor != null)
        {
            foreach (var item in _colliderDoor)
            {
                item.enabled = false;
            }
        }
        Open = false;
        KO.SetActive(false);
        VestibulWorking.SetActive(true);
        Animator.SetTrigger("Close");
        yield return new WaitForSeconds(1.8f);
        _keyAnim.SetTrigger("Close");
        yield return new WaitForSeconds(1.5f);
       
        if (_collider != null) { _collider.enabled = true; }

    }

}
