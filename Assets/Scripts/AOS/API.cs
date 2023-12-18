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
    public UnityAction<string> ResultNameTextEvent;
    public UnityAction<string, TextHolder> ResultButtonTextEvent;
    public UnityAction<string> InfoLocationText;
    public UnityAction<string, string> ExitApiTextEvent;
    public UnityAction<string> ClueEvent;
    public UnityAction<string, string> ActivateButtonEvent;
    public UnityAction<string, string, string> AttempTextEvent;
    public UnityAction<string, string, string, string> MessageTextEvent;
    public UnityAction<string, string, string, string> MessageTextEvent2;
    public UnityAction<string, string, string, string> MessageTimeText;
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
       
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        WelcomeTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Start);
    }
    [AosAction(name: "Показать информацию отказа")]
    public void showFaultInfo(JObject info, JObject nav)
    {
        Debug.Log("info" + info.ToString());
        Debug.Log("info" + nav.ToString());
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


    }

    [AosAction(name: "Показать сообщение")]
    public void showMessage(JObject info, JObject nav)
    {
        Debug.Log(info.ToString());
        string footerText = "";
        string headerText = "";

        var header = info.SelectToken("header");
        var footer = info.SelectToken("footer");
        var head = info.SelectToken("name");
        var comment = info.SelectToken("text");

        if (header != null && footer != null && head != null && comment != null)
        {
            footerText = HtmlToText.Instance.HTMLToTextReplace(footer.ToString());
            string headText = head.ToString();
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            headerText = HtmlToText.Instance.HTMLToTextReplace(header.ToString());
            MessageTextEvent?.Invoke(headText, commentText, headerText, footerText);          
        }
        else if (header != null && head != null && comment != null)
        {

            string headText = head.ToString();
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            headerText = HtmlToText.Instance.HTMLToTextReplace(header.ToString());
            MessageTextEvent2?.Invoke(headText, commentText, headerText, footerText);
        }
        else if (head != null && comment != null)
        {
            string headText = head.ToString();
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            MessageTimeText?.Invoke(headText, commentText, headerText, footerText);
        }



    }
    [AosAction(name: "Показать сообщение")]
    public void showResult(JObject info, JObject nav)
    {

       
        if (info.SelectToken("name") != null && info.SelectToken("text") != null && info.SelectToken("text") != null)
        {
            string headText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("name").ToString());
            string commentText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString());
            string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
            ResultTextEvent?.Invoke(headText, commentText, evalText);
        }
        var result = info.SelectToken("result");
        // Debug.Log("RESULTTT"+result.ToString());  
        // Debug.Log("MESSAGE   " + message.ToString());

        if (result != null)
        {
            foreach (JObject item in result)
            {

                var name = item.SelectToken("name").ToString();
                ResultNameTextEvent?.Invoke(name);
                var msg = item.SelectToken("msg");
                var list = msg.ToList();
                foreach (var item2 in list)
                {


                    var message2 = item2.SelectToken("msg");
                    var name2 = item2.SelectToken("name");
                    if (name2 != null && message2 != null)
                    {
                      TextHolder text= new TextHolder();
                       
                        foreach (var item3 in message2)
                        {
                            


                            if (item3 != null)
                            {
                              text.text.Add(item3.ToString());
                            }
                           
                        }
                                            
                        ResultButtonTextEvent?.Invoke(name2.ToString(), text);
                    }

                }

            }

        }

    }
    [AosAction(name: "Показать реакцию")]
    public void showTime(string time)
    {


        TimerTextEvent?.Invoke(time);
    }

    [AosAction(name: "Обновить меню")]
    public void updateMenu(JObject exitInfo, JObject resons)
    {
        var attText = "";
        if (exitInfo.SelectToken("text") != null && exitInfo.SelectToken("warn") != null)
        {
            string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
            string warmText = exitInfo.SelectToken("warn").ToString();
            ExitApiTextEvent?.Invoke(exitText, warmText);
            Debug.Log(exitText);

        }

        var attemptText = resons.SelectToken("reasons");
        if (attemptText != null)
        {

            foreach (JObject item in attemptText)
            {
                var roomId = item.SelectToken("apiId");
                var attemp = item.SelectToken("result");
                var attempt = item.SelectToken("attempt");
                var roomIdText = roomId.ToString();
                var attempText = HtmlToText.Instance.HTMLToTextReplace(attemp.ToString());

                var close = item.SelectToken("closed");
                if (close != null)
                {
                    var closed = close.ToString().ToLower();
                    ActivateButtonEvent?.Invoke(roomIdText, closed);
                }
                if (attempt != null)
                {
                    attText = attempt.ToString();
                }
                AttempTextEvent?.Invoke(roomIdText, attempText, attText);
            }
        }
    }
    [AosAction(name: "Показать меню")]
    public void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {
        Debug.Log(resons.ToString());
        var attText = "";
        string headtext = faultInfo.SelectToken("name").ToString();
        string commentText = faultInfo.SelectToken("text").ToString();
        string exitSureText = exitInfo.SelectToken("quest").ToString();
        var attemptText = resons.SelectToken("reasons");
        if (attemptText != null)
        {


            foreach (JObject item in attemptText)
            {
                var roomId = item.SelectToken("apiId");
                var attemp = item.SelectToken("result");
                var roomIdText = roomId.ToString();
                var attempt = item.SelectToken("attempt");

                var close = item.SelectToken("closed");
                if (close != null)
                {
                    var closed = close.ToString();
                    ActivateButtonEvent?.Invoke(roomIdText, closed);
                    Debug.Log(roomIdText.ToString() + closed.ToString());
                }
                if (attempt != null)
                {
                    attText = attempt.ToString();
                }

                var attempText = HtmlToText.Instance.HTMLToTextReplace(attemp.ToString());
                AttempTextEvent?.Invoke(roomIdText, attempText, attText);

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
    [AosAction(name: "Показать подсказку")]
    public void showReasons(JObject reasons)
    {

        Debug.Log(reasons.ToString());
        var clueNumber = reasons.SelectToken("reasons");
        if (clueNumber != null)
        {
            var list = clueNumber.ToArray();
            foreach (var item in list)
            {

                ClueEvent?.Invoke(item.ToString());
            }
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
