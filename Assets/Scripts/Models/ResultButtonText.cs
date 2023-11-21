using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultButtonText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _infoText;

    public void setHeadText(string text)
    {
        _headText.text = text;
    }
    public void setNameText(string text)
    {
        _nameText.text = text;
    }
    public void setInfoText(string text)
    {
        _infoText.text = text;
    }


}
