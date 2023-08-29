using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ZoneTrigger : MonoBehaviour
{
    [SerializeField] private RoomName ZoneName;
    [SerializeField] private GameObject _infoPanel;
    private CameraChanger _cameraChanger;
    private int i = 0;

    private API _api;
    private void Start()
    {
        _api = FindObjectOfType<API>();
        _cameraChanger = FindObjectOfType<CameraChanger>();
    }
    private void OnTriggerEnter(Collider col)
    {
        _api.ConnectionEstablished(ZoneName.ToString().ToLower());
        if (i== 0 && ZoneName != 0)
        {
            _infoPanel.SetActive(true);         
            _cameraChanger.OnEscClick();
            i++;
            Debug.Log(ZoneName.ToString().ToLower());
        }
        
        var aosObject = col.GetComponentInParent<AosObjectBase>();
        if (!aosObject)
            return;
        InstanceHandler.Instance.CurrentRoom = ZoneName;


    }
}
