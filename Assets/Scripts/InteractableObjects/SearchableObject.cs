using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableObject : MonoBehaviour
{
    [SerializeField] private string _objectId;

    [SerializeField] private GameObject _obj;
    public string ObjectId => _objectId;
    private void Start()
    {
        SearchableObjectsHandler.Instance.AddSearchableObject(this);
    }

    public void EnableObject(bool value)
    {
        if (_obj == null)
            return;
        _obj.SetActive(value);
    }
}
