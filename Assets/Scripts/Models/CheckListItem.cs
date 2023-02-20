using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckListItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Sprite _checkInSprite;
    [SerializeField] private Sprite _checkOutSprite;
    [SerializeField] private Image _currentSprite;
    [SerializeField] private Button _button;
    private bool _checked = false;
    private void Start()
    {
        _button.onClick.AddListener(Check);
    }
    public void SetText(string text)
    {
        _name.text = text;
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
