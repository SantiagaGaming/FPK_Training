using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleSystemObject : BaseObject
{
   
    [SerializeField] private ParticleSystem _particleSystem;
    private Collider _collider;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        _particleSystem.Stop();
    }

    public override void OnClicked(InteractHand interactHand)
    {              
            _collider.enabled = false;
            _animator.SetTrigger("Idle");
            _particleSystem.Play();
            StartCoroutine(StopWater());           
    }

    private IEnumerator StopWater()
    {
        yield return new WaitForSeconds(2);

        _particleSystem.Stop();
        _collider.enabled = true;
    }
}
