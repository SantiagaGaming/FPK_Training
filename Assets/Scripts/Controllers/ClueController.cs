using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClueController : MonoBehaviour
{
    [SerializeField] private List<SearchableObject> _clueObjects;



    public void ShowClueObjectInList(string clueName)
    {
        var clueObject = _clueObjects.FirstOrDefault(o => o.GetObjectId == clueName);

        if(clueObject != null)
        {
            clueObject.ShowClueObject();
        }
        
    }
}
