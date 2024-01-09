using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Image _locImage;  
    [SerializeField] private TextMeshProUGUI _locationText;
    [SerializeField] private GameObject _startText;
    [SerializeField] private Button[] _button;
   
    public RoomName ZoneName => _zoneName;
    private ObjectsTranslator _translator = new ObjectsTranslator();



    public bool IsVisited { get; private set; } = false;

    private CameraChanger _cameraChanger;
    private bool _enabled = true;

    private API _api;
    private LocationController _locationController;
    private void Start()
    {
        _api = FindObjectOfType<API>();
        _locationController = FindObjectOfType<LocationController>();
        _cameraChanger = FindObjectOfType<CameraChanger>();
    }
    private void OnTriggerEnter(Collider col)
    {
        var aosObject = col.GetComponentInParent<AosObjectBase>();
        if (!aosObject)
            return;
        InstanceHandler.Instance.CurrentRoom = _zoneName;
        var locationText = _translator.ObjectsRusNames[_zoneName.ToString()];
        _locationText.text = locationText;


        _locationController.SetLocation(_zoneName.ToString().ToLower());

        _api.ConnectionEstablished(_zoneName.ToString().ToLower());
       

        if (_enabled && _zoneName != 0 && StartParametr.Instance.ShowInfoText)
        {
            _cameraChanger.OnEscClick();
            _infoPanel.SetActive(true);    
           _mainPanel.SetActive(false);
           
            _enabled=false;
            Debug.Log(_zoneName.ToString().ToLower());
        }
        if (_button != null && !IsVisited)
        {
            foreach (var button in _button)
            {
                button.enabled = true;
                var but = button.GetComponent<Image>();
                but.color=  new Color(1,1,1,1);                                       
            }
        }
        if(_startText!= null)
        {
            _startText.SetActive(false);
        }
        
        IsVisited = true;
                                    
    }
    private void OnTriggerStay(Collider col)
    {
        Debug.Log("ON COLLIDER");
        InstanceHandler.Instance.CurrentRoom = _zoneName;
        var locationText = _translator.ObjectsRusNames[_zoneName.ToString()];
        _locationText.text = locationText;
    }
    public void SetTextColor(RoomState state)
    {
        if (_locImage == null)
            return;
        if (state == RoomState.Inside)
            _locImage.color = new Color(0.3254902f, 0.7215686f, 0.5921569f);
        if (state == RoomState.Outside)             
        _locImage.color = new Color(0.3058824f, 0.6f, 0.6078432f);

    }
  
}
