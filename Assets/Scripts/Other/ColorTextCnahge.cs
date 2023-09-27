using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ColorTextCnahge : MonoBehaviour
{
    [SerializeField] private CheckListItem[] _checkListItem;


    private void Start()
    {
        
    }
    public void SetColorText()
    {
        var text = _checkListItem[Random.Range(0, _checkListItem.Length)];

        text.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;


        Debug.Log(text);




    }
}
