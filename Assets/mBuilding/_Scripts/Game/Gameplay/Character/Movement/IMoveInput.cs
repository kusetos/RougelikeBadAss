using System;
using System.Collections;
using UnityEngine;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement
{
    public interface IMoveInput 
    {
        public Vector3 GetDirection { get; }
    }
}