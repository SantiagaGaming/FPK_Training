using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScreenButton : BaseButton
{
    [SerializeField] private GameObject _infoScreen;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        _infoScreen.SetActive(false);

    }
}
