using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZoneTag : MonoBehaviour
{
    [SerializeField] private RoomName _roomName;
    [SerializeField] private TextMeshProUGUI _zoneText;
    [SerializeField] private GameObject _editButton;
    public RoomName RoomName => _roomName;

    public void SetRoomText(string text)
    {

        _zoneText.text = text;
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
            Debug.Log("INSETROO))))))M");
    }
}
