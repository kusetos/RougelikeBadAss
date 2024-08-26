using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement
{
    public class BaseMovement
    {
        #region Movement

        private float _movingSpeed;
        private float _speedSmoothing;
        private Vector3 _finalMove;
        private Vector3 _smoothMovementInput = Vector3.zero;
        #endregion
        public BaseMovement(BaseMovementConfig config)
        {
            _movingSpeed = config.MovingSpeed;
            _speedSmoothing = config.SpeedSmoothing;

        }
        public void CalculateMovementSmoothing(Vector3 direction)
        {
            _smoothMovementInput = Vector3.Lerp(_smoothMovementInput, direction, Time.fixedDeltaTime * _speedSmoothing);
        }

        public Vector3 MoveLogic(Vector3 direction)
        {

            CalculateMovementSmoothing(direction);
            _finalMove = ((_smoothMovementInput * _movingSpeed)) * Time.fixedDeltaTime;

            if (_smoothMovementInput.magnitude <= 0.01f)
            {
                _smoothMovementInput = Vector3.zero;
            }
            return _finalMove;
        }


    }

}