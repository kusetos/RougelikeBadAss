using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement
{
    public class MovementWithDash : BaseMovement, IInitializable
    {
/*        [Inject]
        public JumpDash jumpDash;
        [Inject]
        public SprintDash sprintDash;
        [Inject]
        public SlowDownDash slowDownDash;
        [Inject]
        public QuickDash quickDash;*/

        private DashStrategy _currentDash;

        private float _speedMultiplier = 1f;

        public MovementWithDash(BaseMovementConfig config)
            : base(config){}

        public override Vector3 MoveUpdate(Vector3 direction)
        {
            return base.MoveUpdate(direction) * _speedMultiplier;
        }
        public void ResetSpeedMultiplier()
        {
            _speedMultiplier = 1f;
        }
        public float SetSpeedMultiplier { set { _speedMultiplier = value; } }

        public void SwitchDash(DashStrategy newDash)
        {
            if (newDash == _currentDash) return;
            Debug.Log("Switch DASH");

            _currentDash = (DashStrategy)newDash;
        }

        public void DoDash(Transform transform)
        {
            _currentDash.DoDash(transform);
        }

        public void Initialize()
        {
            Debug.Log("Intit movement with dash");
        }
    }
}