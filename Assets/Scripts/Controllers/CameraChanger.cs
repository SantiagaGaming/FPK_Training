using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    [SerializeField] private EscController _escControler;
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private GameObject _menuCamera;
    private bool _changed= true;
    private void OnEnable()
    {
        _escControler.OnMenuEvent += OnEscClick;
    }
    private void OnDisable()
    {
        _escControler.OnMenuEvent -= OnEscClick;
    }
    private void OnEscClick()
    {
        _cameraFadeIn.FadeStart = true;
        if(!_changed)
        {
            _playerCamera.SetActive(false);
            _menuCamera.SetActive(true);
            _changed = true;
        }
        else
        {
            _playerCamera.SetActive(true);
            _menuCamera.SetActive(false);
            _changed = false;
        }
    }

}
