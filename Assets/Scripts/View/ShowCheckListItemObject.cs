using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCheckListItemObject : MonoBehaviour
{
    [SerializeField] private Sprite _notSelected;
    [SerializeField] private Sprite _selected;
    [SerializeField] private Sprite _selectedOpen;
    [SerializeField] private Sprite _noSelectedOpen;
    [SerializeField] private GameObject _checkItemPanel;
    [SerializeField] private GameObject[] _hidePanel;
    [SerializeField] private CheckListItem[] _checkListItem;
    

    private Image _img;
    private Button _button;
    private bool _open;
    private void Start()
    {
        _img= GetComponent<Image>();
        _button= GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        foreach (var item in _checkListItem)
        {
            item.OnCheckSpite += OnSetSprite;
        }
    }
    
    private void OnClick()
    {
        if (!_open)
        {
           
            _open = true;
            OnSetSprite();
            _checkItemPanel.SetActive(true);
            if (_hidePanel != null)
            {
                foreach (var item in _hidePanel)
                {
                    item.SetActive(false);

                }
            }
            
        }
        else
        {
            
            _checkItemPanel.SetActive(false);
            _open = false;
            OnSetSprite();
        }
    }
    
   private bool IsChecked()
    {
        foreach (var item in _checkListItem)
        {
            if(item.Checked)
            {
                return true;
            }
            
        }
        return false;
    }
    public void OnSetSprite()
    {
        if(IsChecked()&&_open )
        {
            _img.sprite = _selectedOpen;
        }
        else if(IsChecked()&& !_open ) 
        {
            _img.sprite = _selected;
        }
        else if (_open)
        {
            _img.sprite = _noSelectedOpen;
        }
        else if (!_open)
        {
            _img.sprite = _notSelected;
        }

    }
}
