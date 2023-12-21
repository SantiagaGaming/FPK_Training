using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuTextView : MonoBehaviour
{
   
    [SerializeField] private Text _exitText;
    [SerializeField] private Text _warnText;
    [SerializeField] private Text _headText;
    [SerializeField] private Text _evalText;
    [SerializeField] private Text _commentText;
    [SerializeField] private Text _nameText;
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameObject _mainPanel;
    

    private CameraChanger _cameraChanger;
    private string _nameTempText = "";
    private void Start()
    {
        _cameraChanger = FindObjectOfType<CameraChanger>();
    }

    public void SetResultText(string headText, string commentText, string evalText)
    {
        _cameraChanger._changed= true;
        _cameraChanger.OnEscClick();
        _mainPanel.SetActive(false);
        _resultPanel.SetActive(true);
        _headText.text = headText;
        _commentText.text = commentText;
        _evalText.text = evalText;
        if (StartParametr.Instance.ShowInfoText)
        {
            _commentText.text = "";
        }

        _cameraChanger.CanTeleport = false;

    }

    public void SetExitText(string exitText, string warntext)
    {
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warntext);
    }

    public void SetResultNameText(string nametext)
    {
        _nameTempText += nametext + "\n" + "\n";
        _nameText.text = _nameTempText;
    }
}
