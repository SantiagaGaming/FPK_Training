using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField] private TextMeshProUGUI _buttonInfoText;
    public override void OnClicked(InteractHand interactHand)
    {
        if (CurrentState == NextButtonState.Start)
        {
            _api.OnInvokeNavAction("next");
            OnNextButtonPressed?.Invoke("next");
            Player.Instance.CanMove = false;
            _buttonInfoText.gameObject.SetActive(false);

        }

        else if (CurrentState == NextButtonState.Fault)
        {
            _api.OnInvokeNavAction("start");
            OnNextButtonPressed?.Invoke("start");
            Player.Instance.CanMove = true;
        }
    }
}
