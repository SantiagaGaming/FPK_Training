using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCheckListItemObject : MonoBehaviour
{
    [SerializeField] private Sprite _notSelected;
    [SerializeField] private Sprite _selected;
    [SerializeField] private GameObject _checkItemObject;
    

    private Image _img;
    private Button _button;
    private bool _open;
    private void Start()
    {
        _img= GetComponent<Image>();
        _button= GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (!_open)
        {
            _checkItemObject.SetActive(true);
        }
        else
        {
            _checkItemObject.SetActive(false);
        }
    }
    public void SetSprite(bool value)
    {
        if(value)
            _img.sprite = _selected;
        else
            _img.sprite = _notSelected;
    }
}
