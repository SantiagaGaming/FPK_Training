using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ZoneExitTextInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _zoneText;
    [SerializeField] private TextMeshProUGUI _textEducation;
    [SerializeField] private TextMeshProUGUI _fixedText;
    [SerializeField] private TextMeshProUGUI _fixedTextUnity;
    [SerializeField] private TextMeshProUGUI _exitTextApi;
    [SerializeField] private MenuButton _exitButton;
    [SerializeField] private CheckListHolder[] _checkListHolders;


    private ObjectsTranslator _translator = new ObjectsTranslator();
    private string _textInfo = "";
    private string _fixedInfo = "";
    private const string OKEYLOCATOINTEXT = "�� ��������� �������� ���� ����.";


    void Start()
    {
        _exitButton.ExitTextButtonEvent += SetZoneText;
    }
    public void SetZoneText()
    {
        SetFixedText();
        SetRoomText();
    }
    public void SetFixedText()
    {
        _fixedInfo = "";
        _fixedText.gameObject.SetActive(true);
        _fixedTextUnity.gameObject.SetActive(true);
        foreach (var checkList in _checkListHolders)         //��������� �������� ���������� 
        {
            if (!checkList.Fixed)
            {

                var zoneName = checkList.RoomName.ToString();

                var zoneText = _translator.ObjectsRusNames[zoneName.ToString()];
                
                _fixedInfo += zoneText + ". ";
            }
            _fixedText.text = _fixedInfo;
            if(_fixedInfo.Length<= 0)                      // ���� ��� ��������� , �� ������ �� ����������
            {
                _fixedText.gameObject.SetActive(false);
                _fixedTextUnity.gameObject.SetActive(false);
            }
        }
    }
    public void SetRoomText()
    {
        if (StartParametr.Instance.ShowInfoText) //�������� �� ����� �������� 
        {
            _textInfo = "";
            _zoneText.gameObject.SetActive(true);
            _textEducation.gameObject.SetActive(true);
            foreach (var zone in InstanceHandler.Instance.ZoneTriggers)
            {
                if (!zone.IsVisited)
                {
                    var zoneName = zone.ZoneName.ToString();                  //���������� ���� ��� �� ��� �� ���� 

                    var zoneText = _translator.ObjectsRusNames[zoneName.ToString()];
                    _textInfo += zoneText + ". ";

                }

            }
            _zoneText.text = _textInfo;

            if (_textInfo.Length <= 0)                      // ���� ����� ���� , �� ������� OKEYLOCATOINTEXT
            {
                _zoneText.text += OKEYLOCATOINTEXT;
                _textEducation.gameObject.SetActive(false);
            }
        }
    }

    public void SetExitApiText(string apiText)
    {
        _exitTextApi.text = apiText;
    }
}
