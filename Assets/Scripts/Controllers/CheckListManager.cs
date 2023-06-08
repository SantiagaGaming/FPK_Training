using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckListManager : MonoBehaviour
{
    [HideInInspector] public List<CheckListItem> Items { get; private set; } = new List<CheckListItem>();

    [SerializeField] private CheckListItem _prefub;
    [SerializeField] private ResultController _resultController;

    private Transform _position;
    private Vector3 _yPoz = new Vector3(0, 150, 0);
    private Vector3 _pos;
    private float _step = 3.5f;

    public ObjectsTranslator Translator { get; private set; } = new ObjectsTranslator();

    private void Start()
    {
        _position = transform;
        StartCoroutine(InstatniateDelay());
    }
    private IEnumerator InstatniateDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate();
    }
    private void Instantiate()
    {
        List<SearchableObject> SortedList = SearchableObjectsHandler.Instance.SearchingList.OrderBy(o => o.GetRoomName).ToList();
        for (int i = 0; i <= SortedList.Count - 1; i++)
        {

            var temp = Instantiate(_prefub, _position);
            temp.transform.position += _yPoz;
            var tempObject = SortedList[i];
            temp.SearchableObject = tempObject;
            string zoneName = Translator.ObjectsRusNames[tempObject.GetRoomName.ToString()];
            if (!Translator.ObjectsRusNames.ContainsKey(tempObject.GetObjectId))
            {
                Debug.Log(tempObject.GetObjectId + " Not found in Dictionary");
            }
                string objectName = Translator.ObjectsRusNames[tempObject.GetObjectId];
           
            temp.SetText(zoneName, objectName);
            Items.Add(temp);

        }
    }
    public void Instantiate(RoomName currentRoom)
    {
        _resultController.SetZoneText(currentRoom);
        if (currentRoom == RoomName.None)
        {
            foreach (var item in Items)
            {
                if (item.Checked)
                    item.EnableCheckItem(true);
                else item.EnableCheckItem(false);
            }
        }
        else
        {
            foreach (var item in Items)
            {
                if (item.SearchableObject.GetRoomName != currentRoom)
                {
                    item.EnableCheckItem(false);
                }
                else
                    item.EnableCheckItem(true);

            }
        }
        SortItems();
    }
    private void SortItems()
    {
        _pos = new Vector3(60, 20, 0);
        foreach (var item in Items)
        {
           if(item.Enabled)
            {
                item.transform.position =transform.position;
                item.transform.localPosition -= _pos;
                _pos.y += _step;
            }
            else item.transform.position = transform.position + _yPoz;
            }
    }
  }

