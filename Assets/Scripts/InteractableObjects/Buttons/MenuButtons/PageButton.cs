using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageButton : BaseMenuButton
{
    [SerializeField] private GameObject _objectToShow;
    [SerializeField] private Image _imageAnother;
    [SerializeField] private Sprite _sprite1;
    [SerializeField] private Sprite _sprite2;
    public bool _buttonPageOne;
    public bool _buttonPageTwo;



    private Image _img;
    private void Start()
    {
        _img= GetComponent<Image>();
    }
    protected override void MenuButtonClick()
    {
       
            if (ObjectToHide != null)
                ObjectToHide.SetActive(false);

            if (_objectToShow != null)
                _objectToShow.SetActive(true);
           _img.sprite = _sprite1;
            _imageAnother.sprite = _sprite2;
                                                   
    }
}
