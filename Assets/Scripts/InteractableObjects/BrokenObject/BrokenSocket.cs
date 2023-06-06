using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenSocket : SearchableObject
{
    [SerializeField] private float _x, _y, _z, _a, _b, _c;
    
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (!value)
        {
            Obj.transform.localPosition= new Vector3 (_a, _b, _c);
            Obj.transform.localRotation = Quaternion.Euler(_x, _y, _z);
        }
            


    }
}
