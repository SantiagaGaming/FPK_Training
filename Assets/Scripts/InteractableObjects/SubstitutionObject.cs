using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstitutionObject : HideableObject
{
    [SerializeField] private GameObject _objToHide;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        _objToHide.SetActive(value);
        
    }


}
    
