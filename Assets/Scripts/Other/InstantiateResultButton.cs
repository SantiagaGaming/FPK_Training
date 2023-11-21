using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InstantiateResultButton : MonoBehaviour
{
    public UnityAction CreateButton;
    [SerializeField] private GameObject _buttonPrefab;   
    [SerializeField] private GameObject _buttonPanel;
    [SerializeField] private GameObject _infoPanel;

    
    public void InstantiateButtons(string nameText, string infoText)
    {
        _buttonPanel.SetActive(true);
       
        Instantiate(_buttonPrefab, _buttonPanel.transform);
       
        //    var temp2 = _buttonPrefab.GetComponent<ResultButtonText>();
        //    temp2.setHeadText(nameText);
        //    temp2.setNameText(nameText);
        //    temp2.setInfoText(infoText);
        //CreateButton?.Invoke();
                
    }
}
