using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class ResultController : MonoBehaviour
{
    [SerializeField] private View _view;
    [SerializeField] private CheckListManager _checkManager;
    [SerializeField] private HideController _hideController;

    private List<string> _hidedObjects;
    private List<string> _checkedObjects = new List<string>();

    private int _gradle;
    private void OnEnable()
    {
        _view.OnResultButtonTap += OnCompareIds;
        _view.OnExitButtonTap += OnExitGame;
    }
    private void OnDisable()
    {
        _view.OnResultButtonTap -= OnCompareIds;
        _view.OnExitButtonTap -= OnExitGame;
    }
    private void OnCompareIds()
    {
        _hidedObjects = _hideController.HidedObjectNames;
        AddChechedItems();
        _view.EnableCheckPanel(false);
        _view.EnableResultPanel(true);
        if(_gradle<0)
            _gradle = 0;
        _view.SetResultText(_gradle.ToString());
    }
    private void AddChechedItems()
    {
        _gradle = 0;
        _checkedObjects.Clear();
        ObjectsTranslator translator = _checkManager.Translator;
        for (int i = 0; i < _checkManager.Items.Count; i++)
        {
            if (_checkManager.Items[i].Checked)
            {
                string checkedId = _checkManager.Items[i].CheckName;
                var id = translator.ObjectsRusNames.FirstOrDefault(i => i.Value == checkedId).Key;
                if(id!=null)
                {
                    _checkedObjects.Add(id);
                    if(_hidedObjects.FirstOrDefault(i => i ==id)!=null)
                        _gradle += 20;
                    else _gradle -= 20;
                }
            
            }   
        }
    }
    private void OnExitGame()
    {
        Application.Quit();
    }

}
