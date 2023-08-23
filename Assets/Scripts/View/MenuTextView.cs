using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _exitSureText;
    //[SerializeField] private TextMeshProUGUI _exitText;
    //[SerializeField] private TextMeshProUGUI _warnText;
    public void SetMenuText(string headText, string commentText, string exitSureText)
    {
        
        _infoHeaderText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _exitSureText.text = HtmlToText.Instance.HTMLToTextReplace(exitSureText);
    }

    //public void SetExitText(string exitText, string warntext)
    //{
    //    _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
    //    _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warntext);
    //}
}
