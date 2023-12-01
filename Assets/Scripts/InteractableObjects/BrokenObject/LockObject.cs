using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LockObject : BaseObject
{
    [SerializeField] private LockEnabableObject _lockObject;
    [SerializeField] private NotCloseObject _notCloseObject;
    [SerializeField] private Door _door;
    [SerializeField] private Animator[] _animator;
    private bool _open = true;
    public bool SpecKey = false; //���� ����
    public bool SecretKey = false; // �������� 
    public bool ThreeGranyKey = false;

    private void Start()
    {


        if (_door != null)
        {
            _door.DoorEvent += OnDoorClosed;
            _door.DoorEventOpen += OnDoorOpen;
        }
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (_lockObject.CurrentState == "Idle" && _open)
        {
            //_animator.SetTrigger(_lockObject.CurrentState);

            _open = false;

            if (ThreeGranyKey && !_notCloseObject.BrokenKey)
            {

                _door.UseDoorByCollide(true); // ���� ���� ����������� , �� ��������� �������� �����
            }
            if (ThreeGranyKey && _notCloseObject.BrokenKey)
            {
                _door.UseBroken(true);
            }
            if (SecretKey)
            {
                OnDoorOpen();
                _door.LockedSecretKey = true; // ��������� �������� ��-�� ��������
            }
            if (SpecKey && !_notCloseObject.BrokenKey) // ���� ����� �� ������ , �� ������� � if � ��������� ������������� ����� 
            {
                OnDoorOpen();
                _door.LockedSpecKey = true; // ��������� �������� ��-�� ���������
            }
            if (SpecKey && _notCloseObject.BrokenKey) // ���� ����� ������, �� ���� �������� ������ �� ��������
            {
                OnDoorOpen();
                _open = true;
            }

        }
        else if (_lockObject.CurrentState == "Idle" && !_open)
        {
            if (SecretKey)
            {
                OnDoorClosed();
                _door.LockedSecretKey = false;
            }
            if (SpecKey)
            {
                OnDoorClosed();
                _door.LockedSpecKey = false;
            }
            if (ThreeGranyKey && !_notCloseObject.BrokenKey)
            {
                _door.UseDoorByCollide(false);

            }
            if (ThreeGranyKey && _notCloseObject.BrokenKey)
            {
                _door.UseBroken(false);
            }

            _open = true;

        }
        else
        {
            BrokenDoor();
        }
    }
    private void OnDoorClosed()
    {
        StartCoroutine(OnDoorCloserCor());
    }
    private void OnDoorOpen()
    {
       StartCoroutine(OnDoorOpenCor());
    }
    private void BrokenDoor()
    {
        StartCoroutine(BrokenDoorCor());
    }
    private IEnumerator OnDoorCloserCor()
    {
        foreach (var animator in _animator)
        {
            animator.SetTrigger("Reverse");
            yield return new WaitForSeconds(2f);
        }

    }
    private IEnumerator OnDoorOpenCor()
    {
        {
            foreach (var animator in _animator)
            {
                animator.SetTrigger("Idle");
                yield return new WaitForSeconds(2.7f);
            }

        }
    }
    private IEnumerator BrokenDoorCor()
    {
        foreach (var animator in _animator)
        {
            animator.SetTrigger("Broken");
            yield return new WaitForSeconds(1.5f);
        }
    }

}
