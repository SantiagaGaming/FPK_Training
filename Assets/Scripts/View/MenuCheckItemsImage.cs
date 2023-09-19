using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCheckItemsImage : MonoBehaviour
{
    [SerializeField] private Sprite _selected;
    [SerializeField] private Sprite _selectedOpen;

    public static MenuCheckItemsImage Instance;

   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
   public void SelectedSprite(Image image)
    {
        image.sprite = _selected;
    }
    public void SelectedOpenSprite(Image image)
    {
        image.sprite = _selectedOpen;
    }



}
