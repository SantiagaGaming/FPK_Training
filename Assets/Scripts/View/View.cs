using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public UnityAction OnBackButtonTap;

    [SerializeField] private Text _infoLocationScreenText;
    [SerializeField] private Text _infoText;

                  
    public void InvokeBackButtonTap()
    {
        OnBackButtonTap?.Invoke();
    }
    public void SetInfoLocationScreenText(string text)
    {
       
        _infoLocationScreenText.text = HtmlToText.Instance.HTMLToTextReplace(text);
        _infoText.text = "";
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(text);
    }
    
}

