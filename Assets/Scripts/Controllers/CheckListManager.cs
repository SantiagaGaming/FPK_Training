using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckListManager : MonoBehaviour
{
    [SerializeField] private CheckListItem _prefub;
    private Transform _position;
    private Vector3 _pos = new Vector3();
    private float _step = 3.5f;


    private ObjectsTranslator _translator= new ObjectsTranslator();


    private void Start()
    {
        _position = transform;
        _pos = new Vector3(20, 80, 0);
        StartCoroutine(InstatniateDelay());
    }
    private IEnumerator InstatniateDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate();
    }
    private void Instantiate()
    {
        for (int i = 0; i < 12; i++)
        {
           var temp = Instantiate(_prefub, _position);
            string tempName = SearchableObjectsHandler.Instance.SearchingList[i].GetObjectId;
            temp.SetText(_translator.ObjectsRusNames[tempName]);
            temp.transform.localPosition -= _pos;
            _pos.y -= _step;
            Debug.Log(temp.transform.position);
        }
    }


}
