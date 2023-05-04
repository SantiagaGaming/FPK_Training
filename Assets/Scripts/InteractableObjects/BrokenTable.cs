using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenTable : SearchableObject

{
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);

        if(!value)
            Obj.transform.localRotation =Quaternion.Euler(0, 5, 10);
        

        
    }
}
