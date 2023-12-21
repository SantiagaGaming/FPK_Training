using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InstantiateResultButton : MonoBehaviour
{
    
    [SerializeField] private ResultButtonText _buttonPrefab;   
    [SerializeField] private GameObject _buttonPanel;
    [SerializeField] private InfoPanelModel _infoPanelPrefab;
    [SerializeField] private GameObject _infoCreatePanel;
    [SerializeField] private RexultApiText _rexultApiText;
    [SerializeField] private InfoPanelController _infoPanelController;
  //  [SerializeField] private AccordoinView _accordoinView;
   
   


    public void InstantiateButtons(string nameText, TextHolder infoText)
    {
              
       var headerButton =   Instantiate(_buttonPrefab, _buttonPanel.transform);
        var infoPanel =  Instantiate(_infoPanelPrefab, _infoCreatePanel.transform);
        _infoPanelController.AddPanel(infoPanel);
        
        foreach (var item in infoText.text)
        {
           var itemText= Instantiate(_rexultApiText, infoPanel.GetGameObject());
            itemText.setInfoText(item);
        }
        
      //  _accordoinView.setInfoText(nameText);
      //  _accordoinView.setInfoText2(infoText);
       Debug.Log(nameText);
       Debug.Log(infoText);
        headerButton.setNameText(nameText);
      //  infoPanel.setNameText(nameText);      

        headerButton.ButtonClickEvent += infoPanel.ShowInfo;
        
    }
   

}
