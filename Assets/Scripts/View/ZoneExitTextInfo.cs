using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ZoneExitTextInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _zoneText;
    [SerializeField] private TextMeshProUGUI _textEducation;
    [SerializeField] private MenuButton _exitButton;
    [SerializeField] private CheckListHolder[] _checkListHolders;
    

    private ObjectsTranslator _translator = new ObjectsTranslator();
    private string _textInfo = "";
    private const string OKEYLOCATOINTEXT = "Вы произвели проверку всех мест.";


    void Start()
    {
        _exitButton.ExitTextButtonEvent += SetZoneText;
    }
    public void SetZoneText()
    {
        if (StartParametr.Instance.ShowInfoText) //проверка на режим обучения 
        {
            _textInfo = "";
            _zoneText.gameObject.SetActive(true);                      
            _textEducation.gameObject.SetActive(true);
            foreach (var zone in InstanceHandler.Instance.ZoneTriggers)
            {
                if (!zone.IsVisited)
                {
                    var zoneName = zone.ZoneName.ToString();                  //Записываем зоны где мы еще не были 

                    var zoneText = _translator.ObjectsRusNames[zoneName.ToString()];
                    _textInfo += zoneText + ". ";

                }

            }
            _zoneText.text = _textInfo;

            if (_textInfo.Length <= 0)                      // если везде были , то выводим OKEYLOCATOINTEXT
            {
                _zoneText.text += OKEYLOCATOINTEXT;
                _textEducation.gameObject.SetActive(false);
            }
        }
        foreach (var checkList in _checkListHolders)
        {
            if (!checkList.Fixed)
            {
               
            }
        }
       
    }
}
