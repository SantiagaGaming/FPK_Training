using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private MenuTextView _menuTextView;

    private void Start()
    {
        _api.OnShowMenuText += OnSetExitText;
    }
    private void OnSetExitText(string exitText, string warntext , string text)
    {
        _menuTextView.SetMenuText(exitText, warntext , text);
    }

}
