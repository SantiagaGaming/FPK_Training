using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotationObject : SearchableObject
{

    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private float _z;
    [SerializeField] private Door _door;
    [SerializeField] private Collider _collider;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if(_collider!= null) { _collider.enabled = value; }
        if (!value)
            Obj.transform.localRotation = Quaternion.Euler(_x, _y, _z);
        if (_door == null)
            return;
        _door.open = true;                              

    }
}
