using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckListItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Sprite _checkInSprite;
    [SerializeField] private Sprite _checkOutSprite;
    [SerializeField] private Image _currentSprite;
    [SerializeField] private Button _button;
    public string CheckName { get; private set; }

    private bool _checked = false;
    public bool Checked => _checked;
    private void Start()
    {
        _button.onClick.AddListener(Check);
    }
    public void SetText(string text)
    {
        var date = DateTime.Now;
 

        _name.text = $"{date.ToString("dd/MM/yyyy")}       {text} ";
        CheckName = text;
    }
    private void Check()
    {
        if(!_checked)
        {
            _currentSprite.sprite = _checkInSprite;
            _checked = true;
        }
        else
        {
            _currentSprite.sprite = _checkOutSprite;
            _checked = false;
        }
    }
}
