using UnityEngine;
using System;

namespace MyProject.Runtime.Gameplay
{
    [Serializable]
    public struct MouseLookDirectionComponent
    {
        [HideInInspector] public Vector2 Direction;
        public Transform CameraTransform;
        public float Sensitivity;
        public float MaxAngle;
    }
}