using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof (Button))]
public class SubmitCheckListButton : MonoBehaviour
{
    private Button _button;
    public UnityAction SubmitButtonClick;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    private void Start()
    {
        _button.onClick.AddListener(() => { SubmitButtonClick?.Invoke(); }); 
    }
}
