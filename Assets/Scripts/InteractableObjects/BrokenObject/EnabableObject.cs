using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabableObject : SearchableObject
{
    [SerializeField] private WaterButtons[] _buttons;
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        Obj.SetActive(value);
       if(_buttons != null)
        {
            foreach(var button in _buttons)
            {
                button.SetCondition(value);
            }
        }
    }
}
