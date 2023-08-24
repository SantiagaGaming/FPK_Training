using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;

    public void SetHeaderText(string text)
    {
        _headerText.text = text;
    }
    public void SetCommentText(string text)
    {
        _commentText.text = text;
    }
}
