using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;


[AosSdk.Core.Utils.AosObject(name: "Сломать объект")]
public class BreakObject : AosObjectBase
{
   private SearchableObject _obj;
    private void Awake()
    {
        _obj = GetComponent<SearchableObject>();
        if (_obj == null)
        {
            Debug.Log("Searchable Object null" + gameObject.name);
        }
    }

    [AosAction(name: "Сломать объект")]
    public void Break()
    {
        Debug.Log("Broken!");
        _obj.EnableObject(false);
    }

}