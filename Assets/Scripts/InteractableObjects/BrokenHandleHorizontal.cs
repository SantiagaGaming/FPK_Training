using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenHandleHorizontal : SearchableObject
{
    [SerializeField] private GameObject[] _handle;
    [SerializeField] private float _z;

    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        var brokenHandle = _handle[Random.Range(0, _handle.Length)];
        brokenHandle.transform.localRotation = Quaternion.Euler(0, 0, _z);
    }
}
