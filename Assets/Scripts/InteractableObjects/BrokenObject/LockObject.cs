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

    private Animator _animator;
    private bool _open = true;
    public bool SpecKey = false; //���� ����
    public bool SecretKey = false; // �������� 
    public bool ThreeGranyKey = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
                _animator.SetTrigger(_lockObject.CurrentState);
                _door.LockedSecretKey = true; // ��������� �������� ��-�� ��������
            }
            if (SpecKey && !_notCloseObject.BrokenKey) // ���� ����� �� ������ , �� ������� � if � ��������� ������������� ����� 
            {
                _animator.SetTrigger(_lockObject.CurrentState);
                _door.LockedSpecKey = true; // ��������� �������� ��-�� ���������
            }
            if (SpecKey && _notCloseObject.BrokenKey) // ���� ����� ������, �� ���� �������� ������ �� ��������
            {
                _animator.SetTrigger(_lockObject.CurrentState);
                _open = true;
            }

        }
        else if (_lockObject.CurrentState == "Idle" && !_open)
        {
            if (SecretKey)
            {
                _animator.SetTrigger("Reverse");
                _door.LockedSecretKey = false;
            }
            if (SpecKey)
            {
                _animator.SetTrigger("Reverse");
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
            _animator.SetTrigger(_lockObject.CurrentState);
        }
    }
    private void OnDoorClosed()
    {
        _animator.SetTrigger("Reverse");
    }
    private void OnDoorOpen()
    {
        _animator.SetTrigger("Idle");
    }

}
