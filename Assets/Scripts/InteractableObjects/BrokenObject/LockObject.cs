using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObject : BaseObject
{
    [SerializeField] private LockEnabableObject _lockObject;
    [SerializeField] private NotCloseObject _notCloseObject;
    [SerializeField] private Door _door;
    private Animator _animator;
    private bool _open = true;
    public bool SpecKey = false; //спец ключ
    public bool SecretKey = false; // —екретка 

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }
    public override void OnClicked(InteractHand interactHand)
    {
        if(_lockObject.CurrentState =="Idle" && _open)
        {
            _animator.SetTrigger(_lockObject.CurrentState);
            _open= false;
            if(SecretKey)
            {
                _door.LockedSecretKey = true; // блокирует открытие из-за секретки
            }           
            if (SpecKey && !_notCloseObject.BrokenKey) // если замок не сломан , то заходит в if и позвол€ет заблокировать дверь 
            {
                _door.LockedSpecKey = true; // блокирует открытие из-за спецключа
            }
            if (SpecKey && _notCloseObject.BrokenKey) // если замок сломан, то ключ крутитс€ только на закрытие
            {
                _open= true;
            }



        }
        else if (_lockObject.CurrentState == "Idle" && !_open)
        {
            _animator.SetTrigger("Reverse");
            _open = true;

            if (SecretKey)
            {
                _door.LockedSecretKey = false;
            }
            if (SpecKey)
            {
                _door.LockedSpecKey = false;
            }

        }
        else
        {
            _animator.SetTrigger(_lockObject.CurrentState);
        }
        
       
    }
}
