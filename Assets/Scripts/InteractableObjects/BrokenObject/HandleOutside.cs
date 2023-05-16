using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleOutside : SearchableObject

{
    [SerializeField] private GameObject[] _handlers;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if(!value)
        {
            var randomHandler = _handlers[Random.Range(0, _handlers.Length)];
            randomHandler.transform.localRotation = Quaternion.Euler(0, 0, -3);
        }

    }
}
