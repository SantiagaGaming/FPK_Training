using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotCloseObject : SearchableObject
{
    public bool BrokenKey = false;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (!value)
        {
            BrokenKey= true;
            
        }
    }
}
