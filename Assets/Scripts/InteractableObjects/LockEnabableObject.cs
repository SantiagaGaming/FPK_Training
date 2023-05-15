using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEnabableObject : SearchableObject
{
    private string _broken = "Broken";
    public string CurrentState = "";
    protected override void Start()
    {
        base.Start();
        CurrentState = "Idle";
}
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (!value)
            CurrentState = _broken;
    }
}
