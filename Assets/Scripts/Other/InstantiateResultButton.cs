using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InstantiateResultButton : MonoBehaviour
{
    
    [SerializeField] private GameObject _buttonPrefab;   
    [SerializeField] private GameObject _buttonPanel;
    [SerializeField] private GameObject _infoPanelPrefab;
    [SerializeField] private GameObject _infoCreatePanel;
 


    

    

    public void InstantiateButtons(string nameText, string infoText)
    {
        _buttonPanel.SetActive(true);
       
        Instantiate(_buttonPrefab, _buttonPanel.transform);
        Instantiate(_infoPanelPrefab, _infoCreatePanel.transform);
       
           var headerButton = _buttonPrefab.GetComponent<ResultButtonText>();
           var infoPanel = _infoPanelPrefab.GetComponent<InfoPanelModel>();
        headerButton.setNameText(nameText);
        infoPanel.setNameText(nameText);
        infoPanel.setInfoText(infoText);




    }

}
