using AosSdk.Core.PlayerModule;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    //[SerializeField] private StartGameButton _startGameButton;
    //[SerializeField] private CameraChanger _cameraChanger;
    //[SerializeField] private GameObject _startScreen;
    //[SerializeField] private TimerHelper _timerHelper;

    //private void Start()
    //{
    //    Player.Instance.CanMove = false;
    //    _cameraChanger.CanTeleport= false;
    //}
    //private void OnEnable()
    //{
    //    //_startGameButton.OnStartButtonClick += OnStartGame;
    //}
    //private void OnDisable()
    //{
    //   // _startGameButton.OnStartButtonClick -= OnStartGame;
    //}
    //private void OnStartGame()
    //{

    //    Player.Instance.CanMove = true;
    //    _cameraChanger.CanTeleport = true;
    //    _startScreen.SetActive(false);
    //    _timerHelper.StartGame = true;
    //}

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
    }
    private void OnHideStartScreen(string value)
    {
        if (value == "start")
            _startScreen.SetActive(false);
    }
}
