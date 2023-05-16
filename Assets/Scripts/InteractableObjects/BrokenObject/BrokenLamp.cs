using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLamp : SearchableObject
{
    [SerializeField] private GameObject[] _lamp;

    public override void EnableObject(bool value)
    {
        
        if (!value)
        {
            var brokenLamp = _lamp[Random.Range(0, _lamp.Length)];
            brokenLamp.SetActive(value);
        }
    }
}
