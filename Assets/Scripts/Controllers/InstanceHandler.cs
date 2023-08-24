using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceHandler : MonoBehaviour
{
    public static InstanceHandler Instance;
    [SerializeField] private List<ZoneTag> _zoneTags;
    [HideInInspector] public RoomName CurrentRoom { get; set; } = RoomName.None;
    public List<ZoneTag> ZoneTags => _zoneTags;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
