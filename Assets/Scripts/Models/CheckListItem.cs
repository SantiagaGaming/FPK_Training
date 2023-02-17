using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckListItem : MonoBehaviour
{
    [SerializeField] private Text _name;
    public void SetText(string text)
    {
        _name.text = text;
    }
}
