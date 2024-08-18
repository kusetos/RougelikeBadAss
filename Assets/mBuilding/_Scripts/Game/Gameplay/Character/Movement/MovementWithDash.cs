using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement
{
    public class MovementWithDash : BaseMovement
    {
        private IDashable _currentDash;

        private float _speedMultiplier = 1f;

        public MovementWithDash(BaseMovementConfig config)
            : base(config)
        {
            _currentDash = new SprintDash();
        }

        public override Vector3 MoveUpdate(Vector3 direction)
        {
            return base.MoveUpdate(direction) * _speedMultiplier;
        }
        public void ResetSpeedMultiplier()
        {
            _speedMultiplier = 1f;
        }
        public float SetSpeedMultiplier { set { _speedMultiplier = value; } }

        public void DoDash()
        {
            _currentDash.Dash(this);
        }
        public void SwitchDash(IDashable newDash)
        {
            _currentDash = newDash;
        }

    }
}