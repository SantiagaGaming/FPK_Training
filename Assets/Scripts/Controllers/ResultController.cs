using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    [SerializeField] private View _view;
    [SerializeField] private CheckListManager _checkManager;
    [SerializeField] private HideController _hideController;
    [SerializeField] private CameraChanger _cameraChanger;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    private List<string> _hidedObjects;
    private List<string> _checkedObjects = new List<string>();
    private List<string> _nonCorrectList= new List<string>();

    private  ObjectsTranslator _translator;
    private TempFileWriter _tempFileWriter;

    private int _gradle;
    private void Start()
    {
        _translator = _checkManager.Translator;
    }
    private void OnEnable()
    {
        _view.OnSumbitButtonTap += OnSubmit;
        _view.OnResultButtonTap += OnCompareIds;
        _view.OnExitButtonTap += OnExitGame;
        _view.OnBackButtonTap += OnBack;
    }
    private void OnDisable()
    {
        _view.OnSumbitButtonTap -= OnSubmit;
        _view.OnResultButtonTap -= OnCompareIds;
        _view.OnExitButtonTap -= OnExitGame;
        _view.OnBackButtonTap -= OnBack;
    }
    private void OnBack()
    {
        _view.DisableCheckObjects();
    }
    private void OnSubmit()
    {
        SearchableObjectsHandler.Instance.CurrentRoom = RoomName.None;
        _checkManager.Instantiate(SearchableObjectsHandler.Instance.CurrentRoom);
        _view.EnableCheckObjects();
    }
    private void OnCompareIds()
    {
        EndTime = DateTime.Now;
        _hidedObjects = _hideController.HidedObjectNames;
        OnAddCheckedItems();
        _view.EnableCheckPanel(false);
        _view.EnableResultPanel(true);
        _cameraChanger.CanTeleport = false;
        if(_gradle<0)
            _gradle = 0;
        _view.SetResultText(_gradle.ToString()+"%");
        _view.SetResultCommentText($"\nНачал выполенение: {StartTime}\nЗакончил выполенение: {EndTime} {SetNonCorrectItems()}{SetNotFoundedeItems()}");
        string writeText = $"Иванов Олег Викторович \n Оценка: {_gradle.ToString()}\n Начал выполенение: {StartTime}\n Закончил выполенение: {EndTime} \n Ошибки: \n {SetNonCorrectItems()} \n {SetNotFoundedeItems()}";

        _tempFileWriter = new TempFileWriter();
        _tempFileWriter.WriteFile(writeText);
    }
    private void OnAddCheckedItems()
    {
        _gradle = 0;
        _checkedObjects.Clear();
        for (int i = 0; i < _checkManager.Items.Count; i++)
        {
            if (_checkManager.Items[i].Checked)
            {
                string checkedId = _checkManager.Items[i].CheckName;
                var id = _translator.ObjectsRusNames.FirstOrDefault(i => i.Value == checkedId).Key;
                var roomName = SearchableObjectsHandler.Instance.SearchingList.FirstOrDefault(i=> i.GetObjectId == id);
                if (id!=null)
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
                        _nonCorrectList.Add(_translator.ObjectsRusNames[roomName.GetRoomName.ToString()]+": " + _translator.ObjectsRusNames[id]);
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
        {
           var roomName = SearchableObjectsHandler.Instance.HidedList.FirstOrDefault(i => i.GetObjectId == item);
            notFound += _translator.ObjectsRusNames[roomName.GetRoomName.ToString()]+ ": " + _translator.ObjectsRusNames[item] + ";\n";
        }
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
        _view.SetZoneText(_translator.ObjectsRusNames[name.ToString()]);
    }
    private void OnExitGame()
    {
        Application.Quit();
    }
}
