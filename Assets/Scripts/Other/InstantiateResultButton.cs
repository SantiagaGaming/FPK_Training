using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InstantiateResultButton : MonoBehaviour
{
    
    [SerializeField] private ResultButtonText _buttonPrefab;   
    [SerializeField] private GameObject _buttonPanel;
    [SerializeField] private InfoPanelModel _infoPanelPrefab;
    [SerializeField] private GameObject _infoCreatePanel;
 


    

    

    public void InstantiateButtons(string nameText, string infoText)
    {
       
       
       var headerButton =   Instantiate(_buttonPrefab, _buttonPanel.transform);
       var infoPanel =  Instantiate(_infoPanelPrefab, _infoCreatePanel.transform);                
        headerButton.setNameText(nameText);
        infoPanel.setNameText(nameText);
        infoPanel.setInfoText(infoText);
        headerButton.ButtonClickEvent += infoPanel.ShowInfo;
        




    }

}
