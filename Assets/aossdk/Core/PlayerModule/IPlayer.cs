using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.PlayerModule
{
    public interface IPlayer
    {
        bool CanMove { get; set; }

        bool CanRun { get; set; }

        void Init();

        void TeleportTo(Transform target);

        void TeleportTo(float x, float y, float z);

        void TeleportTo(string objectName);

        void ForwardTo(Transform target);
        void ReleaseForwarding();

        void EnableCamera(bool value);

        void EnableRayCaster(bool value);

        void GrabObject(string objectName, int hand);
        void DropObject(int hand);

        void SetCrouchState(bool state);

        void FadeIn(float speed, bool isInstant);

        void FadeOut(float speed, bool isInstant);

        Camera EventCamera { get; set; }

        GameObject GameObject { get; set; }

        FadeController FadeController { get; set; }
    }
}