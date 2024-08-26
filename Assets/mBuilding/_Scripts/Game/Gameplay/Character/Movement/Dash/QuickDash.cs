using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    //[CreateAssetMenu(fileName = "new QuickDash", menuName = "Movement/Dashes/QuickDash")]

    public class QuickDash : IDashStrategy
    {
        private PlayerGravity _gravity;

        public float _jumpForce = 20f;


        public void DoDash(Transform transform)
        {
            CharacterMovemet characterMovemet = transform.GetComponent<CharacterMovemet>();
            characterMovemet.SetGravityVel(_jumpForce);

        }

        public void StopDash(Transform transform)
        {
        }
    }
}