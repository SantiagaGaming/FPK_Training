using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableObject : SearchableObject
{
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        Obj.SetActive(!value);
    }
}
