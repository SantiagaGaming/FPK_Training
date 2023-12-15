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
    [SerializeField] private ZoneExitTextInfo _zoneExitTextInfo;
    [SerializeField] private ClueController _clueController;
    [SerializeField] private MessageTimeView _messageTimeView;
    [SerializeField] private InstantiateResultButton _instantiateResultButton;



    private void Start()
    {

        _api.ExitApiTextEvent += OnSetExitTextApi;
        _api.AttempTextEvent += OnChangeText;
        _api.MessageTextEvent += OnSetMessageText;
        _api.MessageTextEvent2 += OnSetMessageText2;
        _api.MessageTimeText += OnNewSetMessageTimeText;
        _api.WelcomeTextEvent += OnSetStartText;
        _api.InfoLocationText += OnSetInfoLocationScreen;
        _api.TimerTextEvent += OnSetTimerText;
        _api.ExitTextEvent += OnSetExitText;
        _api.ResultTextEvent += OnSetResultText;
        _api.ActivateButtonEvent += OnActivateButton;
        _api.ClueEvent += OnShowClue;
        _api.ResultNameTextEvent += OnSetResultNameText;
        _api.ResultButtonTextEvent += OnSetResultButton;
    }

    private void OnSetResultButton(string nameText, TextHolder infoText)
    {

        _instantiateResultButton.InstantiateButtons(nameText, infoText);
    }

    private void OnSetResultNameText(string nameText)
    {
        _menuTextView.SetResultNameText(nameText);
    }
    private void OnNewSetMessageTimeText(string headText, string commetText, string headerText, string footerText)
    {
        _messageTimeView.SetClueTimeText(commetText);
    }


    private void OnSetMessageText2(string headText, string commetText, string headerText, string footerText)
    {

        _messageView.SetHeaderText(headText);
        _messageView.SetCommentText(commetText);
        _messageView.SetTextText(headerText);
        _messageView.SetFooterText(footerText);
        _menuHider.EnableMessagePanel(true);

    }

    private void OnSetExitTextApi(string exitText, string warmText)
    {
        _zoneExitTextInfo.SetExitApiText(exitText, warmText);
    }

    private void OnSetResultText(string headText, string commentText, string evalText)
    {
        _menuTextView.SetResultText(headText, commentText, evalText);

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

    private void OnChangeText(string roomNameText, string attempText, string attText)
    {
        var textToChange = InstanceHandler.Instance.ZoneTags.FirstOrDefault(z => z.RoomName.ToString().ToLower() == roomNameText);
        if (textToChange != null)
            textToChange.SetRoomText(attempText, attText);
    }
    private void OnSetMessageText(string headText, string commetText, string headerText, string footerText)
    {
        _messageView.SetHeaderText(headText);
        _messageView.SetCommentText(commetText);
        _messageView.SetTextText(headerText);
        _messageView.SetFooterText(footerText);
        _menuHider.EnableMessagePanel(true);
    }
    private void OnActivateButton(string roomNameText, string closed)
    {
        var textToChange = InstanceHandler.Instance.ZoneTags.FirstOrDefault(z => z.RoomName.ToString().ToLower() == roomNameText);
        textToChange.OnActivateButton(closed);

    }
    private void OnShowClue(string clueId)
    {

        _clueController.ShowClueObjectInList(clueId);
    }

}
