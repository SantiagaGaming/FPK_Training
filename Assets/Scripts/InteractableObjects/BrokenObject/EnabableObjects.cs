using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabableObjects : SearchableObject
{
    [SerializeField] private GameObject[] _objects;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        Obj.SetActive(value);
        foreach (var item in _objects)
        {
            item.SetActive(value);
        }
 
    }
}
