using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanelModel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText; 
    [SerializeField] private TextMeshProUGUI _info;

    public void setNameText(string text)
    {
        _nameText.text = text;
    }
    public void setInfoText(string text)
    {
        _info.text = text;
    }
    public void ShowInfo()
    {
        gameObject.SetActive(true);
    }
}
