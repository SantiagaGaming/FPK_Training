using AosSdk.Core.PlayerModule;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class StartGameController : MonoBehaviour
{
   
    [SerializeField] private CameraChanger _cameraChanger;
    [SerializeField] private CursorManager _cursorManager;
   

    private void Start()
    {
        Player.Instance.CanMove = false;
       _cameraChanger.CanTeleport= false;
    }
    

    [SerializeField] private GameObject _startScreen;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;
    [SerializeField] private StartGameButton _nextButton;
  
    
    
    private void OnEnable()
    {
        _nextButton.OnNextButtonPressed += OnHideStartScreen;
    }
    private void OnDisable()
    {
        _nextButton.OnNextButtonPressed -= OnHideStartScreen;
    }
    public void EnableStartScreen(string headerText, string commentText, string buttonText, NextButtonState state)
    {

        _startScreen.SetActive(true);
        _headerText.text = headerText;
        _commentText.text = commentText;
        _nextButtonText.text = buttonText;
        _nextButton.CurrentState = state;            
        _cursorManager.Locked = false;
       
    }
    private void OnHideStartScreen(string value)
    {
        if (value == "start")
        {
            _startScreen.SetActive(false);
            Player.Instance.CanMove = true;
            _cameraChanger.CanTeleport = true;
            _cursorManager.Locked = true;
        }
       
    }
}
