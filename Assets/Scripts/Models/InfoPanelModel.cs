using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanelModel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText; 
   // [SerializeField] private TextMeshProUGUI _info;
    [SerializeField] private GameObject _gameObject;
    
    public void setNameText(string text)
    {
        _nameText.text = text;
    }
    public void setInfoText(string text)
    {
      //  _info.text = text;
    }
    public void ShowInfo()
    {
        HideInfoPanel();
        gameObject.SetActive(true);
    }

    public Transform GetGameObject()
    {
        return _gameObject.transform;
    }
    public void HideInfoPanel() 
    {
        var list = InfoPanelController.Instance.PanelModel;
        foreach (var item in list)
        {
            item.gameObject.SetActive(false);
        }
        
    }
}
