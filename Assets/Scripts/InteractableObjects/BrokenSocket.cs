using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenSocket : SearchableObject
{
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (!value)
            Obj.transform.localRotation = Quaternion.Euler(0, 0, 20);
    }
}