using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.Player
{
    [AosObject(name: "Игрок")]
    public class Player : AosObjectBase, IPlayer
    {
        [SerializeField] private DesktopPlayer.DesktopPlayer desktopPlayer;
        [SerializeField] private VRPlayer.VRPlayer vrPlayer;

        public static Player Instance { get; internal set; }

        public bool CanMove
        {
            get => _canMove;
            set
            {
                _canMove = value;
                desktopPlayer.CanMove = _canMove;
                vrPlayer.CanMove = _canMove;
            }
        }

        private bool _canMove = true;

        private void Start()
        {
            Instance ??= this;

            RuntimeData.Instance.CurrentPlayer = this;
        }

        public LaunchMode LaunchMode
        {
            set
            {
                desktopPlayer.gameObject.SetActive(value == LaunchMode.Desktop);
                vrPlayer.gameObject.SetActive(value == LaunchMode.Vr);

                if (value != LaunchMode.Desktop)
                {
                    vrPlayer.InitializeOpenXR();
                    return;
                }

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        public void TeleportTo(Transform target)
        {
            desktopPlayer.TeleportTo(target);
            vrPlayer.TeleportTo(target);
        }

        [AosAction("Телепортировать игрока в координаты")]
        public void TeleportTo([AosParameter("Координата x")] float x, [AosParameter("Координата y")] float y, [AosParameter("Координата z")] float z)
        {
            desktopPlayer.TeleportTo(x, y, z);
            vrPlayer.TeleportTo(x, y, z);
        }

        [AosAction("Телепортировать игрока к объекту")]
        public void TeleportTo([AosParameter("Имя объекта")] string objectName)
        {
            desktopPlayer.TeleportTo(objectName);
            vrPlayer.TeleportTo(objectName);
        }

        public void EnableCamera(bool value)
        {
            desktopPlayer.EnableCamera(value);
            vrPlayer.EnableCamera(value);
        }

        public void EnableRayCaster(bool value)
        {
            desktopPlayer.EnableRayCaster(value);
            vrPlayer.EnableRayCaster(value);
        }

        [AosAction("Взять объект в руку")]
        public void GrabObject([AosParameter("Имя объекта")] string objectName, [AosParameter("Индекс руки. 0 - левая, 1 - правая")] int hand)
        {
            desktopPlayer.GrabObject(objectName, hand);
            vrPlayer.GrabObject(objectName, hand);
        }

        [AosAction("Выпустить объект из руки")]
        public void DropObject([AosParameter("Индекс руки. 0 - левая, 1 - правая")] int hand)
        {
            desktopPlayer.DropObject(hand);
            vrPlayer.DropObject(hand);
        }
    }
}