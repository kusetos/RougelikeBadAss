﻿using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    public class SprintDash : IDashable
    {

        private float _sprintSpeed = 1.5f;
        private MovementWithDash _movement;
        [Inject]
        public void Constructor(MovementWithDash movementWithDash, float sprintSpeed)
        {
            _movement = movementWithDash;
            _sprintSpeed = sprintSpeed;
        }
        public void Dash(MovementWithDash movement)
        {
            movement.SetSpeedMultiplier = _sprintSpeed;
        }
    }
}