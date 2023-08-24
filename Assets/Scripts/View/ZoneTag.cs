using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZoneTag : MonoBehaviour
{
    [SerializeField] private RoomName _roomName;
    [SerializeField] private TextMeshProUGUI _zoneText;
    public RoomName RoomName => _roomName;

    public void SetRoomText(string text)
    {
        _zoneText.text = text;
    }
}
