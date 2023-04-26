using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WcTapObject : SearchableObject
{
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if(!value)

        Obj.transform.localPosition= new Vector3(-9.67135f, 2.23151f, 0.7417f);
        Obj.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);

    }
}
