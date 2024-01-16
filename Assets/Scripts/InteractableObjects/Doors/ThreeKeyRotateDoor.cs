using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThreeKeyRotateDoor : Door
{
    

    [SerializeField] private bool _inside;
    [SerializeField] private bool _x;
    [SerializeField] private bool _down;
    [SerializeField] private float _doorParametrStart; // ��������� ��������� ��� ������
    [SerializeField] private float _doorParametrEnd; // ��������  ��� ������
    [SerializeField] private float _finishBrokenParametr; // �������� ����� � ����� ��� ������
    [SerializeField] private float _closePatametr; // ������ ��������  
    [SerializeField] private float _closePatametr2; // ����� ��������
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _collider; // �������� ������� ������� ����� ��������� 
    [SerializeField] private Collider _childrenCollider; // ��������� ����� , ��� �� �� ��������� �������� 
    [SerializeField] private Collider _colliderBlock;
    [SerializeField] private Door[] _checkDoors;
    public float DelayOpen = 5.2f;
    public float DelayClose = 3f;

    override protected IEnumerator UseDoor(bool value)
    {
        WaitCursor.Instance.WaitCursorAnim(true);
        if (_childrenCollider != null) { _childrenCollider.enabled = false; }

        DoorAction(true);

            if (!_inside)
            {

                if (!value)
            {
                LockedOpen = false;
                Debug.Log("5");
                    
                    yield return new WaitForSeconds(0.5f);
                    int y = 0;
                    while (y >= -90)
                    {
                        transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
                DoorEvent?.Invoke();
                if (_collider != null) { _collider.enabled = true; }
                if (_colliderBlock != null) { _colliderBlock.enabled = false; }
                if (_checkDoors != null)
                {
                    foreach (var door in _checkDoors)
                    {
                        if (door.LockedOpen)
                        {
                            _collider.enabled = false;
                        }
                    }
                }
                if (_animator!= null) { _animator.SetTrigger("Open");
                }
               


            }
                else
                {
                LockedOpen = true;
                DoorEventOpen?.Invoke();
                Debug.Log("6");
                if (_animator != null)
                {
                    _animator.SetTrigger("Close");
                }
                if (_collider != null) { _collider.enabled = false; }
                if (_colliderBlock != null) { _colliderBlock.enabled = true; }


                yield return new WaitForSeconds(DelayOpen);
                    int y = -90;
                    while (y <= 0)
                    {
                        transform.localEulerAngles -= new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y++;
                    }
               

            }
            }
            else
            {
                if (!value)
                {
                LockedOpen = false;
                Debug.Log("7");
               
                yield return new WaitForSeconds(1f);
                    int y = 0;
                    while (y <= 90)
                    {
                        transform.localEulerAngles -= new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y++;
                    }
                DoorEvent?.Invoke();
                if (_collider != null) { _collider.enabled = true; }
                if (_colliderBlock != null) { _colliderBlock.enabled = false; }
                if (_checkDoors != null)
                {
                    foreach (var door in _checkDoors)
                    {
                        if (door.LockedOpen)
                        {
                            _collider.enabled = false;
                        }
                    }
                }
                if (_animator != null) { _animator.SetTrigger("Open"); }

                
            }
                else
            {
                LockedOpen = true;
                DoorEventOpen?.Invoke();
                Debug.Log("8");
                if (_colliderBlock != null) { _colliderBlock.enabled = true; }
                if (_animator != null)
                {
                    _animator.SetTrigger("Close");
                }
                if (_collider != null) { _collider.enabled = false; }
                
                yield return new WaitForSeconds(2.5f);
                    int y = 90;
                    while (y >= 0)
                    {
                        transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
               
            }

            }
        if (_childrenCollider != null) { _childrenCollider.enabled = true; }

        DoorAction(false);
            if (open)
                open = false;
            else open = true;
        WaitCursor.Instance.WaitCursorAnim(false);

    }
    
    
    protected override IEnumerator UseBrokenDoor(bool value)
    {
        WaitCursor.Instance.WaitCursorAnim(true);
        if (_childrenCollider != null) { _childrenCollider.enabled = false; }
        DoorAction(true);

        if (!_inside)
        {
            if (!value)
            {
                LockedOpen = false;
                Debug.Log("1");
                if (_colliderBlock != null) { _colliderBlock.enabled = false; }
                float y = _closePatametr;    
                while (y <= _closePatametr2)    
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y++;
                }
                DoorEvent?.Invoke();
                yield return new WaitForSeconds(2.3f);
                transform.localRotation = Quaternion.Euler(transform.rotation.x, _finishBrokenParametr, transform.rotation.z);
                if (_collider != null) { _collider.enabled = true; }
                if (_checkDoors != null)
                {
                    foreach (var door in _checkDoors)
                    {
                        if (door.LockedOpen)
                        {
                            _collider.enabled = false;
                        }
                    }
                }
                if (_animator != null) { _animator.SetTrigger("Open"); }
               
            }
            else
            {
                LockedOpen = true;
                if (_collider != null) { _collider.enabled = false; }
                if (_colliderBlock != null) { _colliderBlock.enabled = true; }
                if (_animator != null) { _animator.SetTrigger("Close"); }
                Debug.Log("2");
                DoorEventOpen?.Invoke();
                yield return new WaitForSeconds(DelayClose);
                float y = _doorParametrStart;   
                while (y >= _doorParametrEnd)
                {
                   
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
                LockedOpen = false;
                Debug.Log("3");


                if (_colliderBlock != null) { _colliderBlock.enabled = false; }
                float y = _closePatametr;
                while (y >= _closePatametr2)
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y--;
                }
                DoorEvent?.Invoke();
                if (_animator != null) { _animator.SetTrigger("Open"); }
                if (_collider != null) { _collider.enabled = true; }
                if (_checkDoors != null)
                {
                    foreach (var door in _checkDoors)
                    {
                        if (door.LockedOpen)
                        {
                            _collider.enabled = false;
                        }
                    }
                }
                yield return new WaitForSeconds(2.3f);
                transform.localRotation = Quaternion.Euler(transform.rotation.x, _finishBrokenParametr, transform.rotation.z);
            }
            else
            {
                LockedOpen = true;
                Debug.Log(" 4");
                if (_colliderBlock != null) { _colliderBlock.enabled = true; }
                if (_collider != null) { _collider.enabled = false; }
                if (_animator != null) { _animator.SetTrigger("Close"); }
                DoorEventOpen?.Invoke();
                yield return new WaitForSeconds(DelayClose);
                float y = _doorParametrStart;
                while (y <= _doorParametrEnd)
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y++;
                }
            }
        }
        if (_childrenCollider != null) { _childrenCollider.enabled = true; }
        DoorAction(false);
        if (open)
            open = false;
        else open = true;
        WaitCursor.Instance.WaitCursorAnim(false);
    }
}
