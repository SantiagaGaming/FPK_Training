using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitZone : ChangeZone
{
    [SerializeField] private CameraChanger _cameraChanger;
    [SerializeField] private ChangeZone _changeZone;
    private bool _inCollider = false;
    private void Start()
    {
        _cameraChanger.MenuEvent += OnChangeState;
    }
   

    private void OnTriggerExit(Collider col)
    {
        var aosObject = col.GetComponentInParent<AosObjectBase>();
        if (!aosObject || _inCollider)
            return;
        Animator.SetTrigger("Close");
        KO.SetActive(false);
        VestibulWorking.SetActive(true);
        _changeZone.Open = false;

    }

    private void OnChangeState(bool value)
    {
        _inCollider= value;
    }
   
}
