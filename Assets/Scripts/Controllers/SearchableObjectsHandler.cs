using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableObjectsHandler : MonoBehaviour
{
    public static SearchableObjectsHandler Instance;

    public List<SearchableObject> SearchingList { get; private set; } = new List<SearchableObject>();
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
        if (obj != null)
        {
            string objectName = obj.ObjectId;
            obj.EnableObject(false);
            SearchingList.Remove(obj);
            return objectName;
        }
        return null;
     
    }
}
