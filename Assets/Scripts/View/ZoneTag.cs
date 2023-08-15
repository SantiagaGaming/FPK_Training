using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTag : MonoBehaviour
{
    [SerializeField] private RoomName _roomName;
    public RoomName RoomName => _roomName;
}
