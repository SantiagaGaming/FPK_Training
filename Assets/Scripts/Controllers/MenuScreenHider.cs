using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuScreenHider : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject[] _allPanels;
    [SerializeField] private CameraChanger _cameraChanger;
    [SerializeField] private GameObject _messageViewPanel;
    private void Start()
    {
        _cameraChanger.MenuEvent += OnHideAllPanels;
    }
    private void OnHideAllPanels(bool value)
    {
        
        if (value)
        {
            HideAllPanels();
            foreach (var zone in InstanceHandler.Instance.ZoneTriggers)
            {
                if (zone.IsVisited)
                    zone.SetTextColor(RoomState.Outside);
            }
            var currentZone = InstanceHandler.Instance.ZoneTriggers.FirstOrDefault(r => r.ZoneName == InstanceHandler.Instance.CurrentRoom);
            if (currentZone != null)
                currentZone.SetTextColor(RoomState.Inside);

        }
       
    }
    private void HideAllPanels()
    {
        foreach (var item in _allPanels)
        {
            item.SetActive(false);
        }
        _mainMenuPanel.SetActive(true);
        
    }
    public void EnableMessagePanel(bool value)
    {
        _messageViewPanel.SetActive(value);
    }
}
