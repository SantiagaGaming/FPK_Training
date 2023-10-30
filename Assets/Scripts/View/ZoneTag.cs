using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZoneTag : MonoBehaviour
{
    [SerializeField] private RoomName _roomName;
    [SerializeField] private TextMeshProUGUI _zoneText;
    [SerializeField] private TextMeshProUGUI _attText;
    [SerializeField] private GameObject _editButton;
    public RoomName RoomName => _roomName;

    public void SetRoomText(string text,string attText)
    {

        _zoneText.text = text;
        _attText.text = attText;
    }
    public void OnActivateButton(string closed)
    {
        if (closed == "true")
            StartCoroutine(ActivateButton(closed));
    }
    private IEnumerator ActivateButton(string closed)
    {
        yield return new WaitForSeconds(0.3f);      
        
           
        _editButton.SetActive(false);
        
    }
}
