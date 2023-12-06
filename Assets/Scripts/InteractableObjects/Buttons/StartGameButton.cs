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
public class StartGameButton : MonoBehaviour
{
    public UnityAction<string> OnNextButtonPressed;
    [HideInInspector] public NextButtonState CurrentState;
    [SerializeField] private API _api;  
    [SerializeField] private TextMeshProUGUI _startButtonText;
    [SerializeField] private Sprite _startSptite;
   
   
     private Button _nextButton;
    private void Awake()
    {
        _nextButton= GetComponent<Button>();
        
    }
    private void Start()
    {
        _nextButton.onClick.AddListener(() => OnClickButton());
    }
    private void OnClickButton()
    {
       
        if (CurrentState == NextButtonState.Start)
        {
            _api.OnInvokeNavAction("next");
            OnNextButtonPressed?.Invoke("next");
            _nextButton.image.sprite = _startSptite;
            _startButtonText.color= Color.white;

        }

        else if (CurrentState == NextButtonState.Fault)
        {
            _api.OnInvokeNavAction("start");
            OnNextButtonPressed?.Invoke("start");
           
        }
    }
}
