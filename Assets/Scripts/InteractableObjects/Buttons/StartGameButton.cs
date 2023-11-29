using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum NextButtonState
{
    Start,
    Fault
}
public class StartGameButton : BaseButton
{
    public UnityAction<string> OnNextButtonPressed;
    [HideInInspector] public NextButtonState CurrentState;
    [SerializeField] private API _api;  
    [SerializeField] private TextMeshProUGUI _startButtonText;
    public override void OnClicked(InteractHand interactHand)
    {
       
        if (CurrentState == NextButtonState.Start)
        {
            _api.OnInvokeNavAction("next");
            OnNextButtonPressed?.Invoke("next");
           Player.Instance.CanMove = false;       
            _startButtonText.text = "Начать";

        }

        else if (CurrentState == NextButtonState.Fault)
        {
            _api.OnInvokeNavAction("start");
            OnNextButtonPressed?.Invoke("start");
            Player.Instance.CanMove = true;
        }
    }
}
