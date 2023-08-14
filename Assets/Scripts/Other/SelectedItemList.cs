using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SelectedItemList : MonoBehaviour
{
    public List<SearchableObject> SelectedItem { get; set; } = new List<SearchableObject> ();

    public static SelectedItemList Instance;
    private void Awake()
    {
        if(Instance == null) 
            
               Instance= this;
             
        
    }
    public void AddObject(SearchableObject obj)
    {
        SelectedItem.Add(obj);
    }
    public void DeleteObject(SearchableObject obj)
    {
      SelectedItem.Remove(obj);
       
    }
}
