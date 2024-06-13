using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterButtons : BaseObject
{
    [SerializeField] private ParticleSystem _particleSystem;
    private Collider _collider;
    private bool _canOn = true;
    private void Start()
    {
        
        _particleSystem.Stop();
        _collider = GetComponent<Collider>();
    }

    public override void OnClicked(InteractHand interactHand)
    {     
        if (_canOn)
        {
            _collider.enabled = false;
            _particleSystem.Play();
            StartCoroutine(StopWater());
        }
       
    }

    private IEnumerator StopWater()
    {
        yield return new WaitForSeconds(3);

        _particleSystem.Stop();
        _collider.enabled = true;
    }
    public void SetCondition(bool value)
    {
        _canOn = value;
    }
}
