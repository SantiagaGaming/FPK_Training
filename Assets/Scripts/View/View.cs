using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public UnityAction OnResultButtonTap;
    public UnityAction OnExitButtonTap;

    [SerializeField] private Button _resultButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _resultCommentText;

    [SerializeField] private GameObject _checkPanel;
    [SerializeField] private GameObject _resultPanel;
    private void Start()
    {
      _resultButton.onClick.AddListener(OnResultButtonTap);
      _exitButton.onClick.AddListener(OnExitButtonTap);
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
}
