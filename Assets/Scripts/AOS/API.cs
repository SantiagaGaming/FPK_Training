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

[AosSdk.Core.Utils.AosObject(name: "API")]
public class API : AosObjectBase
{
    public UnityAction<string> TimerTextEvent;
    public UnityAction<string> InfoLocationText;
    public UnityAction<string> ExitApiTextEvent;
    public UnityAction<string, string> AttempTextEvent;
    public UnityAction<string, string> MessageTextEvent;
    public UnityAction<string, string> ExitTextEvent;
    public UnityAction<string, string, string> ResultTextEvent;
    public UnityAction<string, string, string, NextButtonState> WelcomeTextEvent;
    public UnityAction<string, string, string> MenuTextEvent;
    // public UnityAction<string, string, string, NextButtonState> OnSetStartText;
    [AosEvent(name: "Перемещение игрока")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "Клик по кнопке далее")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "Открыть меню")]
    public event AosEventHandler OnMenu;

    [AosAction(name: "Задать текст приветствия")]
    public void showWelcome(JObject info, JObject nav)
    {
        Debug.Log("SHOWWELCOMEEEEEEE");      
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        WelcomeTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Start);
    }
    [AosAction(name: "Показать информацию отказа")]
    public void showFaultInfo(JObject info, JObject nav)
    {     
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        WelcomeTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Fault);
    }
    [AosAction(name: "Показать место")]
    public void showPlace(JObject place, JArray data, JObject nav)
    {
        string infoLocationText = place.SelectToken("text").ToString();
        InfoLocationText?.Invoke(infoLocationText);
        Debug.Log(infoLocationText);

    }

    [AosAction(name: "Показать сообщение")]
    public void showMessage(JObject info, JObject nav)
    {
        Debug.Log("SSSSSSSShowMessage");
        Debug.Log("SSSSSSSShowMessage" + info.ToString());
        Debug.Log("SSSSSSSShowMessage" + nav.ToString());
        
        string headText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        MessageTextEvent?.Invoke(headText, commentText);
    }
    [AosAction(name: "Показать сообщение")]
    public void showResult(JObject info, JObject nav)
    {
        
        if (info.SelectToken("name") != null && info.SelectToken("text") != null && info.SelectToken("text") != null)
        {
            string headText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("name").ToString());
            string commentText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString());
            string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
            Debug.Log(headText);
            Debug.Log(commentText);
            Debug.Log(evalText);
            ResultTextEvent?.Invoke(headText, commentText, evalText);
        }

        
        
        //string headText = info.SelectToken("name").ToString();
        //string commentText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString());
        //string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
        // string commentText = HtmlToText.Instance.HTMLToTextReplace(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString()));
        //  string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
      //  ResultTextEvent?.Invoke(headText, evalText, commentText);
    }
    [AosAction(name: "Показать реакцию")]
    public void showTime(string time)
    {
        
       
        TimerTextEvent?.Invoke(time);
    }

    [AosAction(name: "Обновить меню")]
    public void updateMenu(JObject exitInfo, JObject resons)
    {
        
        Debug.Log("UPDATEEEE"+exitInfo.ToString());
        if (exitInfo.SelectToken("text") != null)
        {
            string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
            ExitApiTextEvent?.Invoke(exitText);
        }


        var attemptText = resons.SelectToken("reasons");
        if (attemptText != null)
        {
           // Debug.Log(attemptText.ToString() + "inside if");
            foreach (JObject item in attemptText)
            {
                var roomId = item.SelectToken("apiId");
                var attemp = item.SelectToken("result");
                var roomIdText = roomId.ToString();
                var attempText = HtmlToText.Instance.HTMLToTextReplace(attemp.ToString());
                AttempTextEvent?.Invoke(roomIdText, attempText);
            }
        }
    }
    [AosAction(name: "Показать меню")]
    public void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {
        Debug.Log("SHOWMENUUUU"+ exitInfo.ToString());
        Debug.Log("SHOWMENUUUU"+ faultInfo.ToString());
        Debug.Log("SHOWMENU"+resons.ToString());
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
                AttempTextEvent?.Invoke(roomIdText, attempText);
            }
        }
       // MenuTextEvent?.Invoke(headtext, commentText, exitSureText);
        if (exitInfo.SelectToken("text") != null && exitInfo.SelectToken("warn") != null)
        {
            string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
            string warntext = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString());
           // ExitTextEvent?.Invoke(exitText, warntext);
        }

           
      
    }
    public void ConnectionEstablished(string currentLocation)
    {
        EndTween?.Invoke(currentLocation);
    }
    public void OnInvokeNavAction(string value)
    {
        navAction.Invoke(value);
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
