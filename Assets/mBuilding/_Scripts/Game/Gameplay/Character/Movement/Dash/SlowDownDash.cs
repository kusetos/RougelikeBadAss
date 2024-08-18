using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    public class SlowDownDash : IDashable
    {
        private float _slowMultiplier = 0.7f;
        private MovementWithDash _movement;
        [Inject]
        public void Constructor(MovementWithDash movementWithDash, float slowMultiplier)
        {
            _movement = movementWithDash;
            _slowMultiplier = slowMultiplier;
        }
        public void Dash(MovementWithDash movement)
        {
            movement.SetSpeedMultiplier = _slowMultiplier;
        }
    }
}