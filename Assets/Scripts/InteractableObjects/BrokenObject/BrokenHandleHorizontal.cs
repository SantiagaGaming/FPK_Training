using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenHandleHorizontal : SearchableObject
{
    
    [SerializeField] private float _z;
    [SerializeField] private float _y;
    [SerializeField] private float _x;

    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        
        Obj.transform.localRotation = Quaternion.Euler(_x, _y, _z);
    }
}
