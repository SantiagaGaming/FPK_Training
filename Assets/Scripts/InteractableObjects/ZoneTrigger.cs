using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;


public class ZoneTrigger : MonoBehaviour
{
    [SerializeField] private RoomName ZoneName;
    [SerializeField] private GameObject _infoPanel;   
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private TextMeshProUGUI _zoneText;

    private CameraChanger _cameraChanger;
    private bool _enabled = true;


    private API _api;
    private void Start()
    {
        
        _api = FindObjectOfType<API>();
        _cameraChanger = FindObjectOfType<CameraChanger>();
    }
    private void OnTriggerEnter(Collider col)
    {
        _api.ConnectionEstablished(ZoneName.ToString().ToLower());
        if (_enabled && ZoneName != 0 && StartParametr.Instance.ShowInfoText)
        {          
            _infoPanel.SetActive(true);    
            _mainPanel.SetActive(false);
            _cameraChanger.OnEscClick();
            _enabled=false;
            Debug.Log(ZoneName.ToString().ToLower());
        }
      
        
           if(_zoneText!= null) 
        {
            _zoneText.color = new Color(0.01490744f, 0.6320754f, 0);
        }
                           
        var aosObject = col.GetComponentInParent<AosObjectBase>();
        if (!aosObject)
            return;
        InstanceHandler.Instance.CurrentRoom = ZoneName;
    }
}
