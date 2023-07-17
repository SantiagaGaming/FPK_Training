using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotCloseObject : SearchableObject
{
    [SerializeField] private float _y;
    [SerializeField] private Door _door;
    public bool BrokenKey = false;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (!value)
        {
            BrokenKey= true;
            if(_door == null)
            {
                return;
            }
            _door.transform.localRotation= Quaternion.Euler(0,_y,0);
            
            
        }
    }
}
