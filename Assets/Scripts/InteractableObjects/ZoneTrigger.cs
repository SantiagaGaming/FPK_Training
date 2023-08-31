using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RoomState
{
    Inside,
    Outside
}

public class ZoneTrigger : MonoBehaviour
{
    [SerializeField] private RoomName _zoneName;
    [SerializeField] private GameObject _infoPanel;   
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private TextMeshProUGUI _zoneText;
    public RoomName ZoneName => _zoneName;

    public bool IsVisited { get; private set; } = false;

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
        _api.ConnectionEstablished(_zoneName.ToString().ToLower());
        if (_enabled && _zoneName != 0 && StartParametr.Instance.ShowInfoText)
        {          
            _infoPanel.SetActive(true);    
            _mainPanel.SetActive(false);
            _cameraChanger.OnEscClick();
            _enabled=false;
            Debug.Log(_zoneName.ToString().ToLower());
        }
      
        IsVisited = true;
                           
        var aosObject = col.GetComponentInParent<AosObjectBase>();
        if (!aosObject)
            return;
        InstanceHandler.Instance.CurrentRoom = _zoneName;
    }
    public void SetTextColor(RoomState state)
    {
        if (_zoneText == null)
            return;
        if (state == RoomState.Inside)
            _zoneText.color = Color.green;
        if (state == RoomState.Outside)
            _zoneText.color = Color.white;
    }
}
