using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;

public class RotateDoorWithParameter : Door
{
    [SerializeField] private bool _inside;
    [SerializeField] private bool _x;
    [SerializeField] private bool _down;
    [SerializeField] private int _rotateValue;
    [SerializeField] private Animator[] _animator;
    [SerializeField] private Collider _colliderOff;


    override protected IEnumerator UseDoor(bool value)
    {
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
                    if (_colliderOff != null) { _colliderOff.enabled = false; }
                    if (_animator != null)
                    {
                        foreach (var animator in _animator)
                        {
                            animator.SetTrigger("Open");
                        }
                        yield return new WaitForSeconds(1f);
                    }
                    yield return new WaitForSeconds(0.3f);
                    
                    int y = 0;
                    while (y >= -_rotateValue)
                    {
                        transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
                }
                else
                {
                    int y = -_rotateValue;
                    if (_colliderOff != null) { _colliderOff.enabled = true; }
                    while (y <= 0)
                    {
                        transform.localEulerAngles -= new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y++;
                    }
                    if (_animator != null)
                    {
                        foreach (var animator in _animator)
                        {
                            animator.SetTrigger("Close");
                        }
                    }
                }
            }
            else
            {
                if (!value)
                {
                    //if (handle != null)
                    //    StartCoroutine(RotateHandle());
                    if (_colliderOff != null) { _colliderOff.enabled = false; }
                    if (_animator != null)
                    {
                        foreach (var animator in _animator)
                        {
                            animator.SetTrigger("Open");
                        }
                        yield return new WaitForSeconds(1f);
                    }
                    
                    yield return new WaitForSeconds(0.3f);
                    int y = 0;
                    while (y <= _rotateValue)
                    {
                        transform.localEulerAngles -= new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y++;
                    }
                }
                else
                {
                    int y = _rotateValue;
                    if (_colliderOff != null) { _colliderOff.enabled = true; }
                    while (y >= 0)
                    {
                        transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
                    if (_animator != null)
                    {
                        foreach (var animator in _animator)
                        {
                            animator.SetTrigger("Close");
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
    public override void UseDoorByCollide(bool value)
    {
        if (transform.localRotation.y > 0 || transform.localRotation.y < 90)
            base.UseDoorByCollide(value);
    }
}
