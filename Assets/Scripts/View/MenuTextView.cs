using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;
    [SerializeField] private TextMeshProUGUI _headText;
    [SerializeField] private TextMeshProUGUI _evalText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameObject _mainPanel;

    private CameraChanger _cameraChanger;
    private void Start()
    {
        _cameraChanger = FindObjectOfType<CameraChanger>();
    }

    public void SetResultText(string headText, string evalText, string commentText)
    {
        _headText.text= headText;
        _evalText.text= evalText;
        _commentText.text= commentText;
        _cameraChanger.OnEscClick();
        _mainPanel.SetActive(false);
        _resultPanel.SetActive(true);
       
    }

    public void SetExitText(string exitText, string warntext)
    {
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warntext);
    }
}
