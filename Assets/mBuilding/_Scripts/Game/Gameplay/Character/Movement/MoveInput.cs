using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement
{
    public class MoveInput : IMoveInput
    {
        private PlayerInput _input;
        private InputAction _moveAction, _dashAction;

        private MovementWithDash _movement;

        [Inject] 
        public void Constructor(PlayerInput input, MovementWithDash movement)
        {
            _input = input;
            _movement = movement;
            _moveAction = _input.PlayerControls.MoveAction;
            _dashAction = _input.PlayerControls.DashAction;

            _dashAction.started += dashAction_started;
            _dashAction.canceled += dashAction_canceled;
        }

        public void DashAction()
        {
            _movement.DoDash();
        }

        private void dashAction_canceled(InputAction.CallbackContext obj)
        {
            _movement.ResetSpeedMultiplier();
        }

        private void dashAction_started(InputAction.CallbackContext obj)
        {
            DashAction();
        }

        public Vector3 GetDirection
        {
            get
            {
                Vector2 inputMovement = _moveAction.ReadValue<Vector2>();
                return new Vector3(inputMovement.x, 0, inputMovement.y);
            }
        }

    }
}