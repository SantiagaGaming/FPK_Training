using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BaseMenuButton : MonoBehaviour
{
    [SerializeField] protected GameObject ObjectToHide;
    protected Button Button;
    protected void Awake()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(() => { MenuButtonClick(); });
    }
    protected virtual void MenuButtonClick()
    {
    }
}
