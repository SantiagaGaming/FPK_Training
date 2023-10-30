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
    public UnityAction<string,string> ExitApiTextEvent;
    public UnityAction<string> ClueEvent;
    public UnityAction<string,string> ActivateButtonEvent;
    public UnityAction<string, string,string> AttempTextEvent;
    public UnityAction<string, string,string,string> MessageTextEvent;
    public UnityAction<string, string> MessageTextEvent2;
    public UnityAction<string, string> ExitTextEvent;
    public UnityAction<string, string, string> ResultTextEvent;
    public UnityAction<string, string, string, NextButtonState> WelcomeTextEvent;
    public UnityAction<string, string, string> MenuTextEvent;
    // public UnityAction<string, string, string, NextButtonState> OnSetStartText;
    [AosEvent(name: "����������� ������")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "���� �� ������ �����")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "��������� ���������")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "������� ����")]
    public event AosEventHandler OnMenu;

    [AosAction(name: "������ ����� �����������")]
    public void showWelcome(JObject info, JObject nav)
    {
        Debug.Log("SHOWWELCOMEEEEEEE");      
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        WelcomeTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Start);
    }
    [AosAction(name: "�������� ���������� ������")]
    public void showFaultInfo(JObject info, JObject nav)
    {     
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        WelcomeTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Fault);
    }
    [AosAction(name: "�������� �����")]
    public void showPlace(JObject place, JArray data, JObject nav)
    {
        string infoLocationText = place.SelectToken("text").ToString();
        InfoLocationText?.Invoke(infoLocationText);
      

    }

    [AosAction(name: "�������� ���������")]
    public void showMessage(JObject info, JObject nav)
    {

         

        string footerText = "";
        string headText = info.SelectToken("name").ToString();
        var header = info.SelectToken("header");
        var footer = info.SelectToken("footer");
        string commentText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString());
        var headerText = HtmlToText.Instance.HTMLToTextReplace(header.ToString());
       
       
       
        if(header !=null && footer != null){
            footerText = HtmlToText.Instance.HTMLToTextReplace(footer.ToString());
            MessageTextEvent2?.Invoke(headerText, footerText);
            
        }
        MessageTextEvent?.Invoke(headText, commentText, headerText, footerText);
       
        
    }
    [AosAction(name: "�������� ���������")]
    public void showResult(JObject info, JObject nav)
    {
        
        if (info.SelectToken("name") != null && info.SelectToken("text") != null && info.SelectToken("text") != null)
        {
            string headText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("name").ToString());
            string commentText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString());
            string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());                       
            ResultTextEvent?.Invoke(headText, commentText, evalText);
        }

        
        
        //string headText = info.SelectToken("name").ToString();
        //string commentText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString());
        //string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
        // string commentText = HtmlToText.Instance.HTMLToTextReplace(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString()));
        //  string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
      //  ResultTextEvent?.Invoke(headText, evalText, commentText);
    }
    [AosAction(name: "�������� �������")]
    public void showTime(string time)
    {
        
       
        TimerTextEvent?.Invoke(time);
    }

    [AosAction(name: "�������� ����")]
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
                    ActivateButtonEvent?.Invoke(roomIdText,closed);
                    
                }
                if (attempt != null)
                {
                    attText = attempt.ToString();
                }
                AttempTextEvent?.Invoke(roomIdText, attempText, attText);
            }
        }
    }
    [AosAction(name: "�������� ����")]
    public void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {      
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
                if(close != null)
                {
                    var closed = close.ToString();
                    ActivateButtonEvent?.Invoke(roomIdText,closed);
                }
                if(attempt != null)
                {
                     attText = attempt.ToString();
                }

                var attempText = HtmlToText.Instance.HTMLToTextReplace(attemp.ToString());
               AttempTextEvent?.Invoke(roomIdText, attempText,attText);
                
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
    [AosAction(name: "�������� ���������")]
    public void showReasons(JObject reasons)
    {
        
        
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
