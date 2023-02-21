using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartGameButton : BaseButton
{
    public UnityAction OnStartButtonClick;
    public override void OnClicked(InteractHand interactHand)
    {
        OnStartButtonClick?.Invoke();
    }
}
