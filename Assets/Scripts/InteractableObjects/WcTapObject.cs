using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WcTapObject : SearchableObject
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    [SerializeField] private float q;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (!value)
        {
       
        Obj.transform.localPosition= new Vector3(x, y, z);
        Obj.transform.localRotation = Quaternion.Euler(0f, 0f, q);
        }
    }
}

    
    
