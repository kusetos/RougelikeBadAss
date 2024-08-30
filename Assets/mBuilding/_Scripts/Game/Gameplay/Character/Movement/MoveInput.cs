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