using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class CheckListItem : MonoBehaviour
{
    [SerializeField] private Sprite _checkInSprite;
    [SerializeField] private Sprite _checkOutSprite;
    [SerializeField] private Image _currentSprite;
    [SerializeField] private Image _img;
    private Button _button;

    [SerializeField] private BreakObject _obj;
    public string Id  => _obj.ObjectId;
    public bool Checked { get; private set; }
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Check);
    }

    private void Check()
    {
        if(!Checked)
        {
            _currentSprite.sprite = _checkInSprite;
            Checked = true;
            _img.color = Color.blue;
        }
        else
        {
            _currentSprite.sprite = _checkOutSprite;
            Checked = false;
            _img.color = Color.white;
        }
    }
}
