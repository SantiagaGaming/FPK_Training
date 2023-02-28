using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckListManager : MonoBehaviour
{
    [HideInInspector] public List<CheckListItem> Items { get; private set; } = new List<CheckListItem>();

    [SerializeField] private CheckListItem _prefub;

    private Transform _position;
    private Vector3 _pos = new Vector3();
    private float _step = 3.5f;

    public ObjectsTranslator Translator { get; private set; } = new ObjectsTranslator();

    private void Start()
    {
        _position = transform;
        _pos = new Vector3(33, 90, 0);
        StartCoroutine(InstatniateDelay());
    }
    private IEnumerator InstatniateDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate();
    }
    private void Instantiate()
    {
        for (int i = 0; i <= SearchableObjectsHandler.Instance.SearchingList.Count-1; i++)
        {
           var temp = Instantiate(_prefub, _position);
            string tempName = SearchableObjectsHandler.Instance.SearchingList[i].GetObjectId;
            temp.SetText(Translator.ObjectsRusNames[tempName]);
            Items.Add(temp);
            temp.transform.localPosition -= _pos;
            _pos.y -= _step;
        }
    }
}
