using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpingWaterObject : BaseObject
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private LockEnabableObject _lockObject;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _particleSystem.Stop();
    }
    public override void OnClicked(InteractHand interactHand)
    {
         if (_lockObject.CurrentState == "Idle")
        {
            _animator.SetTrigger(_lockObject.CurrentState);
            StartCoroutine(PlayWater());
        }
        else
        {
            _animator.SetTrigger(_lockObject.CurrentState);
            StartCoroutine(StopPumping());
          
        }

    }
    
    private IEnumerator PlayWater()
    {
        yield return new WaitForSeconds(2);

        _particleSystem.Play();
        yield return new WaitForSeconds(5);
        _animator.SetTrigger("StopAnim");
        _particleSystem.Stop();
    }
    private IEnumerator StopPumping()
    {
        yield return new WaitForSeconds(4);
        _animator.SetTrigger("StopAnim");
    }
}
