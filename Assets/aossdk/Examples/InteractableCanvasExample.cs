using AosSdk.Core.PlayerModule;
using AosSdk.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AosSdk.Examples
{
    public class InteractableCanvasExample : AosObjectBase
    {
        [SerializeField] private Transform _playerLockedAnchor;
        [SerializeField] private Button _lockButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _buttonOne;
        [SerializeField] private Button _buttonTwo;
        [SerializeField] private TextMeshProUGUI _log;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Dropdown _dropdown;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private ScrollRect _scrollRect;

        public override void OnEnable()
        {
            base.OnEnable();
            
            _lockButton.onClick.AddListener(LockPlayer);
            _exitButton.onClick.AddListener(ExitButtonClicked);
            _buttonOne.onClick.AddListener(ButtonOneClicked);
            _buttonTwo.onClick.AddListener(ButtonTwoClicked);
            _slider.onValueChanged.AddListener(SliderValueChanged);
            _dropdown.onValueChanged.AddListener(DropDownValueChanged);
            _inputField.onEndEdit.AddListener(InputValueChanged);
        }

        private void OnDisable()
        {
            _lockButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
            _buttonOne.onClick.RemoveAllListeners();
            _buttonTwo.onClick.RemoveAllListeners();
            _slider.onValueChanged.RemoveAllListeners();
            _dropdown.onValueChanged.RemoveAllListeners();
            _inputField.onEndEdit.RemoveAllListeners();
        }

        private void LockPlayer()
        {
            var playerInstance = Player.Instance;

            playerInstance.TeleportTo(_playerLockedAnchor);
            playerInstance.CanMove = false;
            playerInstance.CursorLockMode = CursorLockMode.Locked;
            playerInstance.ForwardTo(transform);
        }

        private void ExitButtonClicked()
        {
            AppendToLog($"Нажата кнопка выхода");
            var playerInstance = Player.Instance;
            playerInstance.ReleaseForwarding();
            playerInstance.CanMove = true;
            playerInstance.CursorLockMode = CursorLockMode.None;
        }

        private void InputValueChanged(string value)
        {
            AppendToLog($"Значение поля: {value}");
        }

        private void DropDownValueChanged(int itemIndex)
        {
            AppendToLog($"Выбран итем: {_dropdown.options[itemIndex].text}");
        }

        private void SliderValueChanged(float value)
        {
            AppendToLog($"Значение слайдера: {value}");
        }

        private void ButtonTwoClicked()
        {
            AppendToLog($"Нажата кнопка 2");
        }

        private void ButtonOneClicked()
        {
            AppendToLog($"Нажата кнопка 1");
        }

        private void AppendToLog(string text)
        {
            if (_log.text == string.Empty)
            {
                _log.text = text;
            }
            else
            {
                _log.text += $"<br>{text}";
            }

            _scrollRect.verticalNormalizedPosition = 0;
        }
    }
}