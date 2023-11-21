using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultButtonText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _nameText;

    public  UnityAction<ResultButtonText> ButtonClick;
    private Button _button;
    public string HeadText = "";
    public string InfoText = "";
    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    private void Start()
    {

        _button.onClick.AddListener(OnResultButtonClick);
    }

    private void OnResultButtonClick()
    {
        ButtonClick?.Invoke(this);
        Debug.Log(HeadText);
        Debug.Log(InfoText);


    }


    public void setNameText(string text)
    {
        _nameText.text = text;
    }


}
