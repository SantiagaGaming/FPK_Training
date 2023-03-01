using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class ResultController : MonoBehaviour
{
    [SerializeField] private View _view;
    [SerializeField] private CheckListManager _checkManager;
    [SerializeField] private HideController _hideController;
    [SerializeField] private CameraChanger _cameraChanger;

    private List<string> _hidedObjects;
    private List<string> _checkedObjects = new List<string>();
    private List<string> _nonCorrectList= new List<string>();

    private  ObjectsTranslator _translator;

    private int _gradle;
    private void Start()
    {
        _translator = _checkManager.Translator;
    }
    private void OnEnable()
    {
        _view.OnResultButtonTap += OnCompareIds;
        _view.OnExitButtonTap += OnExitGame;
    }
    private void OnDisable()
    {
        _view.OnResultButtonTap -= OnCompareIds;
        _view.OnExitButtonTap -= OnExitGame;
    }
    private void OnCompareIds()
    {
        _hidedObjects = _hideController.HidedObjectNames;
        AddCheckedItems();
        _view.EnableCheckPanel(false);
        _view.EnableResultPanel(true);
        _cameraChanger.CanTeleport = false;
        if(_gradle<0)
            _gradle = 0;
        _view.SetResultText(_gradle.ToString()+"%");
        _view.SetResultCommentText(SetNonCorrectItems() + SetNotFoundedeItems());
    }
    private void AddCheckedItems()
    {
        _gradle = 0;
        _checkedObjects.Clear();
        for (int i = 0; i < _checkManager.Items.Count; i++)
        {
            if (_checkManager.Items[i].Checked)
            {
                string checkedId = _checkManager.Items[i].CheckName;
                var id = _translator.ObjectsRusNames.FirstOrDefault(i => i.Value == checkedId).Key;
                if(id!=null)
                {
                    _checkedObjects.Add(id);
                    if (_hidedObjects.FirstOrDefault(i => i == id) != null)
                    {
                        _hidedObjects.Remove(id);
                        _gradle += 20;
                    }
                    else
                    {
                        _gradle -= 20;
                        _nonCorrectList.Add(_translator.ObjectsRusNames[id]);
                    }
                }
            }   
        }
    }
    private string SetNonCorrectItems()
    {
        if (_hidedObjects.Count < 1)
            return "";
            string notFound = "\nНе указано: \n";
            foreach (var item in _hidedObjects)
            notFound += _translator.ObjectsRusNames[item] + ";\n";
            return notFound;
    }
    private string SetNotFoundedeItems()
    {
        if (_nonCorrectList.Count < 1)
            return "";
            string notFound = "\nОшибочно указано: \n";
            foreach (var item in _nonCorrectList)
            notFound += item + ";\n";
            return notFound;
    }
    public void SetZoneText(RoomName name)
    {
        if(name ==RoomName.None)
            _view.SetZoneText("");
        else
        _view.SetZoneText(_translator.ObjectsRusNames[name.ToString()]);
    }
    private void OnExitGame()
    {
        Application.Quit();
    }
}
