using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPositionObject : SearchableObject
{
    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private float _z;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);

        if (!value)
            Obj.transform.localPosition =  new Vector3(_x, _y, _z);



    }
}
