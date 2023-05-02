using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenOutsideBox : SearchableObject
{
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (!value)
            Obj.transform.localRotation = Quaternion.Euler(0, 0,-60);
    }
}
