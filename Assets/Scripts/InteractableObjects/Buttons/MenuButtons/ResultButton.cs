using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultButton :MonoBehaviour
{
    [SerializeField] private API _api;
    private Button _button;
    public UnityAction ResultButtonClick;
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
        _api.OnInvokeNavAction("finish");
        
    }
       
       
    
    
}
