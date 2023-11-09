using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton :BaseMenuButton
{
    protected override void MenuButtonClick()
    {
        API api = FindObjectOfType<API>();
        api.OnInvokeNavAction("exit");
       
    }

}

