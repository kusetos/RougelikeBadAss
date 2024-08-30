using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    [CreateAssetMenu(fileName = "new QuickDash", menuName = "Ability/Dash/QuickDash")]

    public class QuickDash : DashStrategy
    {
        private PlayerGravity _gravity;

        public float _jumpForce = 20f;


        public override void DoDash(Transform transform)
        {
            CharacterMovemet characterMovemet = transform.GetComponent<CharacterMovemet>();
            characterMovemet.SetGravityVel(_jumpForce);

        }

        public override void StopDash(Transform transform)
        {
        }
    }
}