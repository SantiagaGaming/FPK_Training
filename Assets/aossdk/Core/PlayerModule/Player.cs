using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.PlayerModule
{
    [AosObject(name: "Игрок")]
    public class Player : AosObjectBase, IPlayer
    {
        [SerializeField] private DesktopPlayer.DesktopPlayer _desktopPlayer;
        [SerializeField] private VRPlayer.VRPlayer _vrPlayer;
        [field: SerializeField] public FadeController FadeController { get; set; }

        public static Player Instance { get; private set; }

        private IPlayer _currentPlayer;

        public Camera EventCamera
        {
            get => _currentPlayer.EventCamera;
            set { }
        }

        public GameObject GameObject { get; set; }

        private bool _canMove = true;

        public bool CanMove
        {
            get => _canMove;
            set
            {
                _canMove = value;
                _currentPlayer.CanMove = _canMove;
            }
        }

        private bool _canRun = true;

        public bool CanRun
        {
            get => _canRun;
            set
            {
                _canRun = value;
                _currentPlayer.CanRun = value;
            }
        }

        public override void OnEnable()
        {
            base.OnEnable();
            Instance ??= this;
        }

        public CursorLockMode CursorLockMode { get; set; }

        public LaunchMode LaunchMode
        {
            set
            {
                _currentPlayer = value == LaunchMode.Desktop ? (IPlayer) _desktopPlayer : _vrPlayer;

                _desktopPlayer.GameObject.SetActive(value == LaunchMode.Desktop);
                _vrPlayer.GameObject.SetActive(value == LaunchMode.Vr);

                _currentPlayer.Init();
                _currentPlayer.FadeController = FadeController;

                Cursor.visible = false;
            }
        }

        public void Init()
        {
        }

        public void TeleportTo(Vector3 target)
        {
            TeleportTo(target.x, target.y, target.z);
        }

        public void TeleportTo(Transform target)
        {
            _currentPlayer.TeleportTo(target);
        }

        [AosAction("Телепортировать игрока в координаты")]
        public void TeleportTo([AosParameter("Координата x")] float x, [AosParameter("Координата y")] float y, [AosParameter("Координата z")] float z)
        {
            _currentPlayer.TeleportTo(x, y, z);
        }

        [AosAction("Телепортировать игрока к объекту")]
        public void TeleportTo([AosParameter("Имя объекта")] string objectName)
        {
            _currentPlayer.TeleportTo(objectName);
        }

        [AosAction("Затемнить экран")]
        public void FadeIn([AosParameter("Скорость затухания")] float speed, [AosParameter("Затухнуть мгновенно?")] bool isInstant)
        {
            _currentPlayer.FadeIn(speed, isInstant);
        }

        [AosAction("Высветлить экран")]
        public void FadeOut([AosParameter("Длительность высветления")] float speed, [AosParameter("Высветлить мгновенно?")] bool isInstant)
        {
            _currentPlayer.FadeOut(speed, isInstant);
        }

        public void ForwardTo(Transform target)
        {
            _currentPlayer.ForwardTo(target);
        }

        public void ReleaseForwarding()
        {
            _currentPlayer.ReleaseForwarding();
        }

        public void EnableCamera(bool value)
        {
            _currentPlayer.EnableCamera(value);
        }

        public void EnableRayCaster(bool value)
        {
            _currentPlayer.EnableRayCaster(value);
        }

        [AosAction("Взять объект в руку")]
        public void GrabObject([AosParameter("Имя объекта")] string objectName, [AosParameter("Индекс руки. 0 - левая, 1 - правая")] int hand)
        {
            _currentPlayer.GrabObject(objectName, hand);
        }

        [AosAction("Выпустить объект из руки")]
        public void DropObject([AosParameter("Индекс руки. 0 - левая, 1 - правая")] int hand)
        {
            _currentPlayer.DropObject(hand);
        }

        [AosAction("Задать состояние приседания")]
        public void SetCrouchState(bool state)
        {
            _currentPlayer.SetCrouchState(state);
        }
    }
}