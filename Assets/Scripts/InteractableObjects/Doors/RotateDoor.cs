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
    [SerializeField] private Animator _stoporAnimator;
    [SerializeField] private GameObject _colliderOn;
    [SerializeField] private GameObject _colliderOff;
    [SerializeField] private Collider _colliderDoorOff;
    [SerializeField] private Collider[] _lockCollider;
    [SerializeField] private Door[] _checkDoors;

    private bool _handlePlay=false;
    
    override protected IEnumerator UseDoor(bool value)
    {
        WaitCursor.Instance.WaitCursorAnim(true);
       
        GetComponent<Collider>().enabled = false;
        if (handle != null && !_handlePlay)
        {
            _handlePlay = true;
            StartCoroutine(RotateHandle());
        }
           
        if (!LockedSecretKey && !LockedSpecKey)
        {
            DoorAction(true);
            
            if (!_inside)
            {

                if (!value)
                {
                    LockedOpen = true;
                    if (_colliderDoorOff != null) { _colliderDoorOff.enabled = false; }
                    if (_lockCollider !=null)
                    {
                        foreach (var col in _lockCollider)
                        {
                            col.enabled = false;
                        }
                    }                   
                    
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
                    if (_stoporAnimator != null)
                    {
                        _stoporAnimator.SetTrigger("Open");
                        yield return new WaitForSeconds(0.5f);

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

                    LockedOpen = false;
                    if (_animator != null)
                    {
                        _animator.SetTrigger("Close");
                        _colliderOff.SetActive(true);
                        _colliderOn.SetActive(false);
                    }
                    yield return new WaitForSeconds(0.8f);
                    if (_stoporAnimator != null)
                    {
                        _stoporAnimator.SetTrigger("Close");
                        yield return new WaitForSeconds(0.5f);
                    }
                    int y = -90;
                    while (y <= 0)
                    {
                        transform.localEulerAngles -= new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y++;
                    }
                    if (_animator2 != null) { _animator2.SetTrigger("Close"); }

                    if (_lockCollider != null)
                    {
                        foreach (var col in _lockCollider)
                        {
                            col.enabled = true;
                        }
                    }
                    if (_colliderDoorOff != null) { _colliderDoorOff.enabled = true; }
                    if(_checkDoors != null)
                    {
                        foreach(var door in _checkDoors)
                        {
                            if (door.LockedOpen)
                            {
                                _colliderDoorOff.enabled = false;
                            }
                        }
                    }
                }
            }
            else
            {
                //if (handle != null)
                //    StartCoroutine(RotateHandle());
                if (!value)
                {
                    LockedOpen = true;
                    if (_colliderDoorOff != null) { _colliderDoorOff.enabled = false; }
                    if (_lockCollider != null)
                    {
                        foreach (var col in _lockCollider)
                        {
                            col.enabled = false;
                        }
                    }
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
                    if (_stoporAnimator != null)
                    {
                        _stoporAnimator.SetTrigger("Open");
                        yield return new WaitForSeconds(0.5f);
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

                    LockedOpen = false;
                    if (_animator != null)
                    {
                        _animator.SetTrigger("Close");
                        _colliderOff.SetActive(true);
                        _colliderOn.SetActive(false);
                    }
                    yield return new WaitForSeconds(0.8f);
                    if (_stoporAnimator != null)
                    {
                        _stoporAnimator.SetTrigger("Close");
                        yield return new WaitForSeconds(0.5f);
                    }
                   
                    int y = 90;
                    while (y >= 0)
                    {
                        transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
                    OnLightObjectOff?.Invoke();
                    if (_animator2 != null) { _animator2.SetTrigger("Close"); }
                    if (_lockCollider != null)
                    {
                        foreach (var col in _lockCollider)
                        {
                            col.enabled = true;
                        }
                    }
                    if (_colliderDoorOff != null) { _colliderDoorOff.enabled = true; }
                    if (_checkDoors != null)
                    {
                        foreach (var door in _checkDoors)
                        {
                            if (door.LockedOpen)
                            {
                                _colliderDoorOff.enabled = false;
                            }
                        }
                    }
                }

            }
           
            DoorAction(false);
            if (open)
                open = false;
            else open = true;
        }
        
        GetComponent<Collider>().enabled = true;
        WaitCursor.Instance.WaitCursorAnim(false);
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
        while (rot != 0)
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
        _handlePlay = false;
    }
    

}

