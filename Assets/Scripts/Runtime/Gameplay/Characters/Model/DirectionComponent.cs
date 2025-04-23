using System;
using UnityEngine;


namespace MyProject.Runtime.Gameplay
{
    [Serializable]
    public struct DirectionComponent
    {
        [HideInInspector] public Vector3 Direction;
    }
}