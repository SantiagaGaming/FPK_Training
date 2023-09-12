using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;


public class RotateDoor : Door
{
    public UnityAction OnLightObjectOn;
    public UnityAction OnLightObjectOff;

    [SerializeField] private bool _inside;
    [SerializeField] private bool _x;
    [SerializeField] private bool _down;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animator2;
    [SerializeField] private GameObject _colliderOn;
    [SerializeField] private GameObject _colliderOff;
    [SerializeField] private Collider _colliderDoorOff;


    override protected IEnumerator UseDoor(bool value)
    {
        if(_colliderDoorOff != null) { _colliderDoorOff.enabled = false;}
        GetComponent<Collider>().enabled = false;
        if (handle != null)
            StartCoroutine(RotateHandle());
        if (!LockedSecretKey && !LockedSpecKey)
        {
            DoorAction(true);
            
            if (!_inside)
            {

                if (!value)
                {
                   
                    //if (handle != null)
                    //    StartCoroutine(RotateHandle());
                    if (_animator2 != null)
                    {
                        _animator2.SetTrigger("Open");
                        yield return new WaitForSeconds(1f);
                    }
                    yield return new WaitForSeconds(0.5f);
                    int y = 0;
                    while (y >= -90)
                    {
                        transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
                    
                    if (_animator != null)
                    {
                        _animator.SetTrigger("Open");
                        _colliderOn.SetActive(true);
                        _colliderOff.SetActive(false);
                    }
                }
                else
                {
                    
                    
                    if (_animator != null)
                    {
                        _animator.SetTrigger("Close");
                        _colliderOff.SetActive(true);
                        _colliderOn.SetActive(false);
                    }
                    yield return new WaitForSeconds(0.6f);
                    int y = -90;
                    while (y <= 0)
                    {
                        transform.localEulerAngles -= new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y++;
                    }
                    if (_animator2 != null) { _animator2.SetTrigger("Close"); }
                }
            }
            else
            {
                //if (handle != null)
                //    StartCoroutine(RotateHandle());
                if (!value)
                {
                    
                    //if (handle != null)
                    //    StartCoroutine(RotateHandle());
                    if (_animator2 != null)
                    {
                        _animator2.SetTrigger("Open");
                        yield return new WaitForSeconds(1f);
                    }
                    yield return new WaitForSeconds(1f);
                    int y = 0;
                    while (y <= 90)
                    {
                        transform.localEulerAngles -= new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y++;
                    }
                    if (_animator != null)
                    {
                        _animator.SetTrigger("Open");
                        _colliderOn.SetActive(true);
                        _colliderOff.SetActive(false);
                    }
                    OnLightObjectOn?.Invoke();
                }
                else
                {
                    
                    if (_animator != null)
                    {
                        _animator.SetTrigger("Close");
                        _colliderOff.SetActive(true);
                        _colliderOn.SetActive(false);
                    }

                    yield return new WaitForSeconds(0.5f);
                    int y = 90;
                    while (y >= 0)
                    {
                        transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
                    OnLightObjectOff?.Invoke();
                    if (_animator2 != null) { _animator2.SetTrigger("Close"); }
                }

            }
           
            DoorAction(false);
            if (open)
                open = false;
            else open = true;
        }
        if (_colliderDoorOff != null) { _colliderDoorOff.enabled = true; }
        GetComponent<Collider>().enabled = true;
    }
    private IEnumerator RotateHandle()
    {
        int rot = 0;
        while (rot <= 45)
        {
            if (!_x && !_down)
                handle.transform.localEulerAngles += new Vector3(0, 0, 1);
            else if (!_x && _down)
                handle.transform.localEulerAngles -= new Vector3(0, 0, 1);
            else if (_x && !_down)
                handle.transform.localEulerAngles -= new Vector3(1, 0, 0);
            else
                handle.transform.localEulerAngles += new Vector3(1, 0, 0);
            yield return new WaitForSeconds(0.008f);
            rot++;
        }
        while (rot >= 0)
        {
            if (!_x && !_down)
                handle.transform.localEulerAngles -= new Vector3(0, 0, 1);
            else if (!_x && _down)
                handle.transform.localEulerAngles += new Vector3(0, 0, 1);
            else if (_x && !_down)
                handle.transform.localEulerAngles += new Vector3(1, 0, 0);
            else
                handle.transform.localEulerAngles -= new Vector3(1, 0, 0);
            yield return new WaitForSeconds(0.008f);
            rot--;
        }
    }
    

}

