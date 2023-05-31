using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenRandomBlinds : SearchableObject
{
    [SerializeField] private BlindsKoridorObject[] _blindsKoridorObjects;
    public override void EnableObject(bool value)
    {
        if(!value)
        {

            var item = _blindsKoridorObjects[Random.Range(0,_blindsKoridorObjects.Length)];
            if (item != null )
            item.BrokenBlinds = "Broken";
            
        }
    }
}
