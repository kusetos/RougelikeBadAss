using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    public class JumpDash : IDashable
    {
        private PlayerGravity _gravity;
        private float _jumpForce = 15f;
        [Inject]
        public void Constructor(PlayerGravity gravity, float jumpForce)
        {
            _gravity = gravity;
            _jumpForce = jumpForce;
        }
        public void Dash(MovementWithDash movement)
        {
            _gravity.Velocity = Vector3.up * _jumpForce;

        }

    }
}