using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class AccordoinView : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _text2;
    
    public void setInfoText(string text)
    {
        _text.text = text;
    }
    public void setInfoText2(string text)
    {
        _text2.text = text;
    }
}
