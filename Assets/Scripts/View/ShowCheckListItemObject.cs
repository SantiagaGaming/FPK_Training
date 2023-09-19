using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCheckListItemObject : MonoBehaviour
{
    [SerializeField] private Sprite _notSelected;
    [SerializeField] private Sprite _noSelectedOpen;
    [SerializeField] private GameObject _checkItemPanel;
    [SerializeField] private CheckListItem[] _checkListItem;
    [SerializeField] private ShowCheckListItemObject[] _showCheckListItem;
    

    private Image _img;
    private Button _button;
    public bool Open;
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
    
   public void OnClick()
    {
        if (!Open)
        {
           
            Open = true;
            OnSetSprite();
            _checkItemPanel.SetActive(true);
           
            if (_showCheckListItem != null)
            {
                foreach (var item in _showCheckListItem)
                {
                    if (item.Open)
                    {
                        item.OnClick();
                    }
                }
            }

        }
        else
        {
            
            _checkItemPanel.SetActive(false);
            Open = false;
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
        if(IsChecked()&&Open )
        {
           
            MenuCheckItemsImage.Instance.SelectedOpenSprite(_img);
        }
        else if(IsChecked()&& !Open ) 
        {
            MenuCheckItemsImage.Instance.SelectedSprite(_img);
          
        }
        else if (Open)
        {
            _img.sprite = _noSelectedOpen;
        }
        else if (!Open)
        {
            _img.sprite = _notSelected;
        }

    }
}
