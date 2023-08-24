using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private MenuTextView _menuTextView;
    [SerializeField] private MessageView _messageView;
    [SerializeField] private MenuScreenHider _menuHider;


    private void Start()
    {
        _api.OnShowMenuText += OnSetExitText;
        _api.OnSetAttemptText += OnChangeText;
        _api.OnSetMessageText += OnSetMessageText;
    }
    private void OnSetExitText(string exitText, string warntext , string text)
    {
        _menuTextView.SetMenuText(exitText, warntext , text);
    }

    private void OnChangeText(string roomNameText, string attempText)
    {
        var textToChange = InstanceHandler.Instance.ZoneTags.FirstOrDefault(z => z.RoomName.ToString().ToLower() == roomNameText);
        if (textToChange != null)
            textToChange.SetRoomText(attempText);
    }
    private void OnSetMessageText(string headText , string commetText)
    {
        _messageView.SetHeaderText(headText);
        _messageView.SetCommentText(commetText);
        _menuHider.EnableMessagePanel(true);
    }
}
