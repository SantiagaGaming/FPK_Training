using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RexultApiText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _info;
    public void setInfoText(string text)
    {
        _info.text = text;
    }
   
}
