using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : BaseButton
{

    public override void OnClicked(InteractHand interactHand)
    {
        API api = FindObjectOfType<API>();
        api.OnInvokeNavAction("exit");
    }
}

