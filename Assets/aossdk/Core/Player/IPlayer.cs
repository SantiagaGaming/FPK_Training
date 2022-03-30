﻿using UnityEngine;

namespace AosSdk.Core.Player
{
    public interface IPlayer
    {
        public bool CanMove { get; set; }

        public void TeleportTo(Transform target);

        public void TeleportTo(float x, float y, float z);

        public void TeleportTo(string objectName);

        public void EnableCamera(bool value);

        public void EnableRayCaster(bool value);
    }
}