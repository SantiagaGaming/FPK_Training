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


    override protected IEnumerator UseDoor(bool value)
    {
        if (!LockedSecretKey && !LockedSpecKey)
        {
            DoorAction(true);

            if (!_inside)
            {

                if (!value)
                {
                    Debug.Log("5");
                    if (handle != null)
                        StartCoroutine(RotateHandle());
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
                    DoorEvent?.Invoke();
                    if (_animator != null)
                    {
                        _animator.SetTrigger("Open");
                        _colliderOn.SetActive(true);
                        _colliderOff.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("6");
                    DoorEvent?.Invoke();
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
                if (!value)
                {
                    Debug.Log("7");
                    if (handle != null)
                        StartCoroutine(RotateHandle());
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
                    Debug.Log("8");
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
    protected override IEnumerator UseBrokenDoor(bool value)
    {

        DoorAction(true);

        if (!_inside)
        {
            if (!value)
            {
                Debug.Log("1");
                int y = -90;
                while (y <= 0)
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y++;
                }
                DoorEvent?.Invoke();
                yield return new WaitForSeconds(2.2f);
                transform.localRotation = Quaternion.Euler(transform.rotation.x, -5, transform.rotation.z);
            }
            else
            {
                Debug.Log("2");
                yield return new WaitForSeconds(3f);
                int y = -5;
                while (y >= -90)
                {
                    //transform.localEulerAngles += new Vector3(0, 1, 0);
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y--;
                }
            }
        }
        else
        {

            if (!value)
            {
                Debug.Log("3");
                yield return new WaitForSeconds(1f);
                int y = 0;
                while (y <= 85)
                {
                    transform.localEulerAngles -= new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y++;
                }
            }
            else
            {
                Debug.Log(" 4");
                int y = 90;
                while (y >= 0)
                {
                    transform.localEulerAngles += new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y--;
                }
            }
        }
        DoorAction(false);
        if (open)
            open = false;
        else open = true;
    }

}

