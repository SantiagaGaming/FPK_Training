using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class SubmitCheckListButton : MonoBehaviour
{
    [SerializeField] private EditButton _editButton;

    private float _delay = 0.2f;
    private Button _button;
    public UnityAction SubmitButtonClick;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    private void Start()
    {
        _button.onClick.AddListener(() => { SubmitButtonClick?.Invoke(); });
    }

    public void HideButtons()
    {
        StartCoroutine(Delay());
        
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
        _editButton.gameObject.SetActive(true);
        foreach (var button in _editButton.Buttons)
        {
            button.enabled = false;
            button.image.color = new Color(1, 1, 1, 0.47f);

        }
    }
}
