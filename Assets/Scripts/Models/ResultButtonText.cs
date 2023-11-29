using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultButtonText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _nameText;

    public  UnityAction ButtonClickEvent;
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    private void Start()
    {
        _button.onClick.AddListener(() => { ButtonClickEvent?.Invoke(); });
    }
 
    public void setNameText(string text)
    {
        _nameText.text = text;
    }
    public void ShowInfo(GameObject infoPanel)
    {
        infoPanel.SetActive(true);
    }


}
