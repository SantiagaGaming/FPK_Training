using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[AosSdk.Core.Utils.AosObject(name: "���")]
public class API : AosObjectBase
{
    public UnityAction OnShowPlace;
    public UnityAction<string> OnSetTeleportLocation;
    public UnityAction<string> OnSetNewLocationText;
    public UnityAction<string> OnSetLocation;
    public UnityAction<string> OnSetLocationForFieldColliders;
    public UnityAction<string> OnActivateBackButton;
    public UnityAction<string> OnSetTimerText;
    public UnityAction<string> OnReaction;
    public UnityAction<string, string> OnSetAttemptText;
    public UnityAction<string, string> OnActivateByName;
    public UnityAction<string, string> OnSetMessageText;
    public UnityAction<string, string, string> OnSetResultText;
    public UnityAction<string, string> OnShowExitText;
    public UnityAction<string, string, string> OnShowMenuText;
    // public UnityAction<string, string, string, NextButtonState> OnSetStartText;

    [AosEvent(name: "����������� ������")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "���� �� ������ �����")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "��������� ���������")]
    public event AosEventHandlerWithAttribute OnMeasure;
    [AosEvent(name: "��������� ���������")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "������� ����")]
    public event AosEventHandler OnMenu;

    public bool MenuTeleport = true;

    public void Teleport([AosParameter("������ ������� ��� �����������")] string location)
    {
        OnSetTeleportLocation?.Invoke(location);
        EndTween?.Invoke(location);
    }
    [AosAction(name: "������ ����� �����������")]
    public void showWelcome(JObject info, JObject nav)
    {
        Debug.Log(info.ToString());
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        //  OnSetStartText?.Invoke(headerText, commentText, buttonText, NextButtonState.Start);
        OnSetTeleportLocation?.Invoke("start");
    }


    [AosAction(name: "�������� ���������� ������")]
    public void showFaultInfo(JObject info, JObject nav)
    {
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        // OnSetStartText?.Invoke(headerText, commentText, buttonText, NextButtonState.Fault);
    }

    public void ConnectionEstablished(string currentLocation)
    {
        EndTween?.Invoke(currentLocation);
    }
    [AosAction(name: "�������� �����")]
    public void showPlace(JObject place, JArray data, JObject nav)
    {
        string location = place.SelectToken("apiId").ToString();
        OnSetLocation?.Invoke(location);
        if (place.SelectToken("name") != null)
        {
            OnSetNewLocationText?.Invoke(place.SelectToken("name").ToString());
        }
        OnShowPlace?.Invoke();
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("apiId");
            if (temp != null)
            {
                OnActivateByName?.Invoke(temp.ToString(), item.SelectToken("name").ToString());
            }
        }
        if (nav.SelectToken("back") != null && nav.SelectToken("back").SelectToken("action") != null && nav.SelectToken("back").SelectToken("action").ToString() != String.Empty)
        {
            OnActivateBackButton?.Invoke(nav.SelectToken("back").SelectToken("action").ToString());
        }
        OnSetLocationForFieldColliders?.Invoke(location);
    }
    [AosAction(name: "������� ������")]
    public void showRefuses(JArray points)
    {
        Debug.Log("IN  SHOWREFUSES  " + points.ToString());
    }


    [AosAction(name: "�������� �������")]
    public void showReaction(JObject info, JObject nav)
    {
        if (info.SelectToken("text") != null)
        {
            var reactionText = info.SelectToken("text").ToString();
            OnReaction?.Invoke(reactionText);
        }
    }

    [AosAction(name: "�������� ���������")]
    public void showMessage(JObject info, JObject nav)
    {
        string headText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        OnSetMessageText?.Invoke(headText, commentText);
    }
    [AosAction(name: "�������� ���������")]
    public void showResult(JObject info, JObject nav)
    {
        string headText = info.SelectToken("name").ToString();
        // string commentText = HtmlToText.Instance.HTMLToTextReplace(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString()));
        //  string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
        // OnSetResultText?.Invoke(headText, commentText, evalText);
    }


    [AosAction(name: "�������� �������")]
    public void showTime(string time)
    {
        OnSetTimerText?.Invoke(time);
    }

    [AosAction(name: "�������� ����")]
    public void updateMenu(JObject exitInfo, JObject resons)
    {
        var attemptText = resons.SelectToken("reasons");
        if (attemptText != null)
        {
            Debug.Log(attemptText.ToString() + "inside if");
            foreach (JObject item in attemptText)
            {
                var roomId = item.SelectToken("apiId");
                var attemp = item.SelectToken("result");
                var roomIdText = roomId.ToString();
                var attempText = HtmlToText.Instance.HTMLToTextReplace(attemp.ToString());
                OnSetAttemptText?.Invoke(roomIdText, attempText);
            }
        }
    }
    [AosAction(name: "�������� ����")]
    public void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {
        //Debug.Log("SHOWMENUUPDATEEEEEONe" + exitInfo.ToString());
        //Debug.Log("SHOWMENUUPDATEEEEE" + faultInfo.ToString());
        //Debug.Log("SHOWMENUREASONS  UPDATEEEEE" + resons.ToString());
        string headtext = faultInfo.SelectToken("name").ToString();
        string commentText = faultInfo.SelectToken("text").ToString();
        string exitSureText = exitInfo.SelectToken("quest").ToString();
        var attemptText = resons.SelectToken("reasons");
        if (attemptText != null)
        {
            Debug.Log(attemptText.ToString() + "inside if");
            foreach (JObject item in attemptText)
            {
                var roomId = item.SelectToken("apiId");
                var attemp = item.SelectToken("result");
                var roomIdText = roomId.ToString();
                var attempText = HtmlToText.Instance.HTMLToTextReplace(attemp.ToString());
                OnSetAttemptText?.Invoke(roomIdText, attempText);
            }
        }


        OnShowMenuText?.Invoke(headtext, commentText, exitSureText);
        // OnSetAttemptText?.Invoke(attemptText,);



        //if (exitInfo.SelectToken("text") != null && exitInfo.SelectToken("warn") != null)

        //    string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
        //    string warntext = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString());
        //    OnShowExitText?.Invoke(exitText, warntext);

    }

    public void OnInvokeNavAction(string value)
    {
        navAction.Invoke(value);
    }
    public void InvokeOnMeasure(string text)
    {
        OnMeasure?.Invoke(text);
    }
    public void OnReasonInvoke(string name)
    {
        OnReason?.Invoke(name);
    }
    public void OnMenuInvoke()
    {
        OnMenu?.Invoke();
    }
}
