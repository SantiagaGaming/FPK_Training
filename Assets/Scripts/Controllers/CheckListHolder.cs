using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckListHolder : MonoBehaviour
{
    [SerializeField] private RoomName _roomName;
    [SerializeField] private List<CheckListItem> _checkListItems;
    [SerializeField] private SubmitCheckListButton _submitCheckListButton;

    private OtkazModel _otkazModel;
    public static UnityAction<OtkazModel> AddNewOtazList;
    private void Start()
    {
        _submitCheckListButton.SubmitButtonClick += OnAddItemsToFaultList;
    }
    private void OnAddItemsToFaultList()
    {
        _otkazModel = new OtkazModel();
        var roomName = _roomName.ToString().ToLower();
        _otkazModel.Place = roomName;
        foreach (var checkItem in _checkListItems)
        {
            if(checkItem.Checked)
            {
                var newotkaz = checkItem.Id;
                _otkazModel.AddOtaz(newotkaz);
            }
        }
        AddNewOtazList?.Invoke(_otkazModel);
    }
}
