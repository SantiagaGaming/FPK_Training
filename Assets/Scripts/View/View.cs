using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public UnityAction OnResultButtonTap;
    public UnityAction OnSumbitButtonTap;
    public UnityAction OnExitButtonTap;
    public UnityAction OnBackButtonTap;

    [SerializeField] private GameObject _resultButton;
    [SerializeField] private GameObject _submitButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _zoneText;
    [SerializeField] private TextMeshProUGUI _resultCommentText;

    [SerializeField] private GameObject _checkPanel;
    [SerializeField] private GameObject _checkText;
    [SerializeField] private GameObject _resultPanel;
    private void Start()
    {
     // _resultButton.GetComponent<Button>().onClick.AddListener(OnResultButtonTap);
      _exitButton.GetComponent<Button>().onClick.AddListener(OnExitButtonTap);
      _submitButton.GetComponent<Button>().onClick.AddListener(OnSumbitButtonTap);
      _backButton.GetComponent<Button>().onClick.AddListener(OnBackButtonTap);
    }
    public void EnableCheckObjects()
    {
        _submitButton.SetActive(false);
        _resultButton.SetActive(true);
        _backButton.SetActive(true);
        _checkText.SetActive(true);
    }
    public void DisableCheckObjects()
    {
        _submitButton.SetActive(true);
        _resultButton.SetActive(false);
        _backButton.SetActive(false);
        _checkText.SetActive(false);
    }

    public void EnableCheckPanel(bool value)
    {
        _checkPanel.SetActive(value);
    }
    public void EnableResultPanel(bool value)
    {
        _resultPanel.SetActive(value);
    }
    public void SetResultText(string text)
    {
        _resultText.text = text;
    }
    public void SetResultCommentText(string text)
    {
        _resultCommentText.text = text;
    }
    public void SetZoneText(string text)
    {
       _zoneText.text = text;
    }
    public void InvokeBackButtonTap()
    {
        OnBackButtonTap?.Invoke();
    }
}
