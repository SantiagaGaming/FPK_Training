using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckListManager : MonoBehaviour
{
    [SerializeField] private CheckListItem _prefub;
    [SerializeField] private Transform _position;
    private Vector3 _pos = new Vector3(960, 540, 0);

    private ObjectsTranslator _translator= new ObjectsTranslator();

    private int _xPoz = 676;
    private int _yPoz = 920;
    private int _yStep = 60;

    private void Start()
    {
        _position.position = _pos;
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
            _yPoz -= _yStep;
            temp.transform.position = new Vector3(_xPoz, _yPoz, 0);
            Debug.Log(temp.transform.position);
        }
    }


}
