using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceHandler : MonoBehaviour
{
    public static InstanceHandler Instance;
    [SerializeField] private List<ZoneTag> _zoneTags;
    [HideInInspector] public RoomName CurrentRoom { get; set; } = RoomName.None;
    public List<SearchableObject> SearchingList { get; private set; } = new List<SearchableObject>();
    public List<SearchableObject> HidedList { get; private set; } = new List<SearchableObject>();
    public List<ZoneTag> ZoneTags => _zoneTags;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void AddSearchableObject(SearchableObject obj)
    {
        SearchingList.Add(obj);
    }
    public string HideObject()
    {
        var obj = SearchingList[Random.Range(0, SearchingList.Count)];
        if (obj == null)
            return null;
            string objectName = obj.GetObjectId;
            obj.EnableObject(false);
            HidedList.Add(obj);
            SearchingList.Remove(obj);
            return objectName;       
    }
}
