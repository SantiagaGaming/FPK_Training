using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitCursor : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _spriteCrossHair;
    private Image _image;

    public static WaitCursor Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        _image= GetComponent<Image>();
       
    }

    public void WaitCursorAnim(bool state)
    {
        if (state)
        {
            _image.enabled = true;           
            StartCoroutine(SetSprite());
        }
        else
        {
            _image.enabled = false;
            _spriteCrossHair.enabled = true;
        }
      
    }
    

    private  IEnumerator SetSprite()
    {
        _spriteCrossHair.enabled= false;
        foreach (var sprite in _sprites)
        {
            _image.sprite = sprite;
            yield return new WaitForSeconds(0.4f);
            
        }
        _image.enabled = false;

    }
}
