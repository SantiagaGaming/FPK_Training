using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnableObject : SearchableObject
{
    [SerializeField] private ParticleSystem _particleSystem;
    protected override void Start()
    {
        base.Start();
        _particleSystem.Stop();
    }

    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if(!value)
        {
            _particleSystem.Play();
        }

    }

}
