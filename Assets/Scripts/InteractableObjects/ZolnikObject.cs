using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZolnikObject : SearchableObject
{
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (!value)
            Obj.transform.localRotation = Quaternion.Euler(-7, 4.2f, 0);
    }

}
