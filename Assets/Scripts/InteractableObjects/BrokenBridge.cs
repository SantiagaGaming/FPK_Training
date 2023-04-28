using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBridge : SearchableObject
{
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if(!value)
        {
            Obj.transform.rotation =Quaternion.Euler(0f, 11f, 0f);
            Obj.transform.localPosition = new Vector3(-0.000269f, 0f, 0f);
        }
    }

}
