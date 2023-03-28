using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EnababaleObjects : SearchableObject
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
