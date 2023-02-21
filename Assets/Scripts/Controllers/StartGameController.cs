using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    [SerializeField] private StartGameButton _startGameButton;
    [SerializeField] private CameraChanger _cameraChanger;
    [SerializeField] private GameObject _startScreen;
    private void Start()
    {
        Player.Instance.CanMove = false;
        _cameraChanger.CanTeleport= false;
    }
    private void OnEnable()
    {
        _startGameButton.OnStartButtonClick += OnStartGame;
    }
    private void OnDisable()
    {
        _startGameButton.OnStartButtonClick -= OnStartGame;
    }
    private void OnStartGame()
    {
        Player.Instance.CanMove = true;
        _cameraChanger.CanTeleport = true;
        _startScreen.SetActive(false);
    }
}
