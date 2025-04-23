using System;
using UnityEngine;

namespace MyProject.Runtime.Gameplay
{
    [Serializable]
    public struct MovableComponent
    {
        public CharacterController CharacterController;
        public float Speed;
        [HideInInspector] public Vector3 Velocity;
    }
}