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


        [Inject] 
        public void Constructor(PlayerInput input)
        {
            _input = input;
            _moveAction = _input.PlayerControls.MoveAction;
            _dashAction = _input.PlayerControls.DashAction;


            _dashAction.started += DashAction_started;
            _dashAction.canceled += DashAction_canceled;
        }
        public event Action DashAction = delegate {};
        public event Action StopDashAction = delegate {};

        private void DashAction_canceled(InputAction.CallbackContext obj)
        {
            StopDashAction?.Invoke();   
        }

        private void DashAction_started(InputAction.CallbackContext obj)
        {
            DashAction?.Invoke();
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