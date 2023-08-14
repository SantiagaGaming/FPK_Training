using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckListItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _zoneName;
    [SerializeField] private TextMeshProUGUI _objectname;
    [SerializeField] private Sprite _checkInSprite;
    [SerializeField] private Sprite _checkOutSprite;
    [SerializeField] private Image _currentSprite;
    [SerializeField] private GameObject _button;
    [HideInInspector] public bool Enabled { get; private set; } = true;

    [HideInInspector] public SearchableObject SearchableObject { get; set; }
    public string CheckName { get; private set; }

    private bool _checked = false;
    public bool Checked => _checked;
    
    private void Start()
    {
        _button.GetComponent<Button>().onClick.AddListener(Check);
    }
    public void SetText(string zoneName,string objectName)
    {
        var date = DateTime.Now;
 

        _zoneName.text = $"{date.ToString("dd/MM/yyyy")}  {zoneName}";
        _objectname.text = objectName;
        CheckName = objectName;
    }
    private void Check()
    {
        if(!_checked)
        {
            _currentSprite.sprite = _checkInSprite;
            _checked = true;          
            SelectedItemList.Instance.AddObject(SearchableObject);
            Debug.Log(SearchableObject.GetObjectId);
        }
        else
        {
            _currentSprite.sprite = _checkOutSprite;
            _checked = false;                    
            SelectedItemList.Instance.DeleteObject(SearchableObject);
            Debug.Log(SearchableObject.GetObjectId);
        }
    }
    public void EnableCheckItem(bool value)
    {
        _zoneName.enabled = value;
        _objectname.enabled = value;
       _button.SetActive(value);
        Enabled= value;
    }
}
