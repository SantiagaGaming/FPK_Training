using System;
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
    [SerializeField] private StartGameController _startGameController;
    [SerializeField] private View _view;
    [SerializeField] private TimerView _timerView;

    private void Start()
    {
      //  _api.MenuTextEvent += OnSetMenuText;
        _api.AttempTextEvent += OnChangeText;
        _api.MessageTextEvent += OnSetMessageText;
        _api.WelcomeTextEvent += OnSetStartText;
        _api.InfoLocationText += OnSetInfoLocationScreen;
        _api.TimerTextEvent += OnSetTimerText;
        _api.ExitTextEvent += OnSetExitText;
    }

    private void OnSetExitText(string exitText, string warntext)
    {
       _menuTextView.SetExitText(exitText, warntext);
    }

    private void OnSetTimerText(string time)
    {
       _timerView.ShowTimerText(time);
    }

    private void OnSetInfoLocationScreen(string infotext)
    {
        _view.SetInfoLocationScreenText(infotext);
    }

    private void OnSetStartText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        _startGameController.EnableStartScreen(headerText, HtmlToText.Instance.HTMLToTextReplace(commentText), buttonText, state);

    }

    private void OnSetMenuText(string exitText, string warntext, string text)
    {
        _menuTextView.SetMenuText(exitText, warntext, text);
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
