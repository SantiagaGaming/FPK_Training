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
}
