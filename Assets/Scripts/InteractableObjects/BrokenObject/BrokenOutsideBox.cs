using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenOutsideBox : SearchableObject
{
    [SerializeField] private GameObject[] _objects;
    public override void EnableObject(bool value)
    {

        base.EnableObject(value);
        if (!value)
            foreach (var item in _objects)
            {
                item.transform.localRotation = Quaternion.Euler(0, 0, -60);
            }
    }

}
