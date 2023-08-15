using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenHider : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject[] _allPanels;
    [SerializeField] private CameraChanger _cameraChanger;
    private void Start()
    {
        _cameraChanger.OnMenuChange += OnHideAllPanels;
    }
    private void OnHideAllPanels(bool value)
    {
        if(value)
        {
            HideAllPanels();
        }
    }
    private void HideAllPanels()
    {
        foreach (var item in _allPanels)
        {
            item.SetActive(false);
        }
        _mainMenuPanel.SetActive(true);
    }



}
