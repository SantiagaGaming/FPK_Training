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

[AosSdk.Core.Utils.AosObject(name: "АПИ")]
public class API : AosObjectBase
{
    public UnityAction OnShowPlace;
    public UnityAction OnResetMeasureButtons;
    public UnityAction<float> OnSetMeasureValue;
    public UnityAction<string> OnSetTeleportLocation;
    public UnityAction<string> OnSetNewLocationText;
    public UnityAction<string> OnSetLocation;
    public UnityAction<string> OnSetLocationForFieldColliders;
    public UnityAction<string> OnActivateBackButton;
    public UnityAction<string> OnEnableDietButtons;
    public UnityAction<string> OnSetTimerText;
    public UnityAction<string> OnAddMeasureButton;
    public UnityAction<string> OnReaction;
    public UnityAction<string, string> OnEnableMovingButton;
    public UnityAction<string, string> OnActivateByName;
    public UnityAction<string, string> OnSetMessageText;
    public UnityAction<string, string, string> OnSetResultText;
    public UnityAction<string, string> OnShowExitText;
    public UnityAction<string, string, string> OnShowMenuText;
    public UnityAction<string, string> OnAddFaultHeader;
    public UnityAction<string, string> OnAddFaultObject;
    public UnityAction<string, string> OnAddFaultInsideHeader;
    public UnityAction<string, string> OnAddFaultInsideObject;
    // public UnityAction<string, string, string, NextButtonState> OnSetStartText;

    [AosEvent(name: "Перемещение игрока")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "Клик по кнопке далее")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnMeasure;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "Открыть меню")]
    public event AosEventHandler OnMenu;

    public bool MenuTeleport = true;

    public void Teleport([AosParameter("Задать локацию для перемещения")] string location)
    {
        OnSetTeleportLocation?.Invoke(location);
        EndTween?.Invoke(location);
    }
    [AosAction(name: "Задать текст приветствия")]
    public void showWelcome(JObject info, JObject nav)
    {
        Debug.Log(info.ToString());
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        //  OnSetStartText?.Invoke(headerText, commentText, buttonText, NextButtonState.Start);
        OnSetTeleportLocation?.Invoke("start");
    }


    [AosAction(name: "Показать информацию отказа")]
    public void showFaultInfo(JObject info, JObject nav)
    {
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        // OnSetStartText?.Invoke(headerText, commentText, buttonText, NextButtonState.Fault);
    }
    public void OnInvokeNavAction(string value)
    {
        navAction.Invoke(value);
    }
    public void ConnectionEstablished(string currentLocation)
    {
        EndTween?.Invoke(currentLocation);
    }
    [AosAction(name: "Показать место")]
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
    [AosAction(name: "Указать отказы")]
    public void showRefuses(JArray points)
    {
        Debug.Log("IN  SHOWREFUSES  " + points.ToString());
    }
    [AosAction(name: "Обновить место")]
    public void updatePlace(JArray data)
    {
        Debug.Log("Enter UpdatePlace");
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("points");
            if (temp != null)
            {
                OnEnableDietButtons(null);
                if (temp is JArray)
                {
                    foreach (var temp2 in temp)
                    {
                        string buttonName = temp2.SelectToken("apiId").ToString();
                        OnEnableDietButtons(buttonName);
                    }
                }
            }
        }
    }


    [AosAction(name: "Показать реакцию")]
    public void showReaction(JObject info, JObject nav)
    {
        if (info.SelectToken("text") != null)
        {
            var reactionText = info.SelectToken("text").ToString();
            OnReaction?.Invoke(reactionText);
        }
    }

    [AosAction(name: "Показать сообщение")]
    public void showMessage(JObject info, JObject nav)
    {
        string headText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        OnSetMessageText?.Invoke(headText, commentText);
        Debug.Log("INFOOOO"+ info.ToString());
        Debug.Log("NAVVVVV"+ nav.ToString());
    }
    [AosAction(name: "Показать сообщение")]
    public void showResult(JObject info, JObject nav)
    {
        string headText = info.SelectToken("name").ToString();
        // string commentText = HtmlToText.Instance.HTMLToTextReplace(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString()));
        //  string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
        // OnSetResultText?.Invoke(headText, commentText, evalText);
    }
    [AosAction(name: "Показать точки")]
    public void showPoints(string info, JArray data)
    {

        OnEnableMovingButton?.Invoke(null, null);
        foreach (JObject item in data)
        {
            if (item == null)
                return;
            if (item.SelectToken("tool") != null && item.SelectToken("name") != null)
            {
                if (item.SelectToken("tool").ToString() == "eye")
                {
                    string eye = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    OnEnableMovingButton?.Invoke(eye, text);
                }
                if (item.SelectToken("tool").ToString() == "hand")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    OnEnableMovingButton?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "tool")
                {
                    string tool = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    OnEnableMovingButton?.Invoke(tool, text);
                }
            }

            else if (item.SelectToken("apiId") != null)
            {
                string buttonName = item.SelectToken("apiId").ToString();
                OnEnableDietButtons?.Invoke(buttonName);
            }
        }
    }

    [AosAction(name: "Показать реакцию")]
    public void showTime(string time)
    {
        OnSetTimerText?.Invoke(time);
    }
    [AosAction(name: "Показать точки измерения")]
    public void showMeasure(JArray measureDevices, JArray measurePoints)
    {
        OnResetMeasureButtons?.Invoke();
        foreach (JObject item in measurePoints)
        {
            var tmpArray = item.SelectToken("points");
            if (tmpArray != null && tmpArray is JArray)
            {
                foreach (JObject item2 in tmpArray)
                {
                    string butonName = item2.SelectToken("apiId").ToString();
                    OnAddMeasureButton?.Invoke(butonName);
                }
            }
        }
    }
    [AosAction(name: "Показать точки измерения")]
    public void showMeasureResult(JObject result, JObject nav)
    {
        Debug.Log("in showFaultInfo Measure Result");
        if (result.SelectToken("result") != null)
        {
            float measureValue = float.Parse(result.SelectToken("result").ToString());
            OnSetMeasureValue?.Invoke(measureValue);
            Debug.Log("in showFaultInfo Measure Result " + measureValue);
        }
    }
    [AosAction(name: "Обновить меню")]
    public void updateMenu(JObject exitInfo, JObject resons)
    {
        Debug.Log("UPDATEEEEEMENU" +exitInfo.ToString()  );
        Debug.Log("REASONSSSSSUPDATEEEEEMENU" + resons.ToString());


    }
    [AosAction(name: "Показать меню")]
    public void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {
        Debug.Log("SHOWMENUUPDATEEEEEONe" + exitInfo.ToString());
        Debug.Log("SHOWMENUUPDATEEEEE" + faultInfo.ToString());
        Debug.Log("SHOWMENUREASONS  UPDATEEEEE" + resons.ToString());
        string headtext = faultInfo.SelectToken("name").ToString();
        string commentText = faultInfo.SelectToken("text").ToString();
        string exitSureText = exitInfo.SelectToken("quest").ToString();
      
        OnShowMenuText?.Invoke(headtext, commentText, exitSureText);

        var reasonsList = resons.SelectToken("reasons");
        if (reasonsList != null)
        {
            foreach (var jObject in reasonsList)
            {
                var headerId = jObject.SelectToken("apiId");
                var headerName = jObject.SelectToken("name");
                if (headerId != null && headerName != null)
                    OnAddFaultHeader?.Invoke(headerId.ToString(), headerName.ToString());
                var reasonsObjectList = jObject.SelectToken("reasons");
                if (reasonsObjectList != null && reasonsObjectList is JArray)
                {
                    foreach (JObject faultObject in reasonsObjectList)
                    {
                        if (faultObject != null)
                        {
                          //  Debug.Log("fault object " + faultObject.ToString());
                            var id = faultObject.SelectToken("apiId");
                            var name = faultObject.SelectToken("name");
                            if (id != null && name != null)
                                OnAddFaultObject?.Invoke(id.ToString(), name.ToString());
                            var lastReason = faultObject.SelectToken("reasons");

                            if (lastReason != null)
                            {
                                foreach (var item in lastReason)
                                {
                                    var idLast = item.SelectToken("apiId");
                                    var nameLast = item.SelectToken("name");
                                    //if (id != null && name != null)
                                    //OnAddFaultInsideObject?.Invoke(idLast.ToString(), nameLast.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        //OnSetLocation?.Invoke(location);
        //if (place.SelectToken("name") != null)
        //{
        //    OnSetNewLocationText?.Invoke(place.SelectToken("name").ToString());
        //}
        //OnShowPlace?.Invoke();
        //foreach (JObject item in data)
        //{
        //    var temp = item.SelectToken("apiId");
        //    if (temp != null)
        //    {
        //        OnActivateByName?.Invoke(temp.ToString(), item.SelectToken("name").ToString());
        //    }
        //}
        //if (nav.SelectToken("back") != null && nav.SelectToken("back").SelectToken("action") != null && nav.SelectToken("back").SelectToken("action").ToString() != String.Empty)
        //{
        //    OnActivateBackButton?.Invoke(nav.SelectToken("back").SelectToken("action").ToString());
        //}
        //OnSetLocationForFieldColliders?.Invoke(location);

        // if (exitInfo.SelectToken("text") != null && exitInfo.SelectToken("warn") != null)
        {
            // string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
            // string warntext = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString());
            // OnShowExitText?.Invoke(exitText, warntext);
        }
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
