using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    public class QuickDash : IDashable
    {
        private PlayerGravity _gravity;
        private Vector3 _jumpForce = new Vector3(0f, 0f, 20f);
        [Inject]
        public void Constructor(PlayerGravity gravity, Vector3 jumpForce)
        {
            _gravity = gravity;
            _jumpForce = jumpForce;
        }
        public void Dash(MovementWithDash movement)
        {
            _gravity.Velocity = _jumpForce;

        }
    }
}