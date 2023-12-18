using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _textText;
    [SerializeField] private TextMeshProUGUI _footerText;
    [SerializeField] private Text _headText;
    [SerializeField] private Text _commenttextt;
    [SerializeField] private Text _texttext;
    [SerializeField] private Text _footertext;

    public void SetHeaderText(string text)
    {
        _headerText.text = text;
        _headText.text = text;
    }
    public void SetCommentText(string text)
    {
        _commentText.text = text;
        _commenttextt.text = text;
    }
    public void SetTextText(string text)
    {
        _textText.text = text;
        _texttext.text = text;
    }
    public void SetFooterText(string text)
    {
        _footerText.text = text;
        _footertext.text = text;
    }
}
