using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageTimeView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _textText;
    [SerializeField] private TextMeshProUGUI _footerText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameObject _timePanel;

    public void SetHeaderText(string text)
    {
        _headerText.text = text;
    }
    public void SetCommentText(string text)
    {
        _commentText.text = text;
    }
    public void SetTextText(string text)
    {
        _textText.text = text;
    }
    public void SetFooterText(string text)
    {
        _footerText.text = text;
    }
    public void SetClueTimeText(string text)
    {
        _timeText.text = text;
        StartCoroutine(ShowTimePanel());

    }
    private IEnumerator ShowTimePanel()
    {
        _timePanel.SetActive(true);
       
        yield return new WaitForSeconds(10);
        _timePanel.SetActive(false);
    }
}
