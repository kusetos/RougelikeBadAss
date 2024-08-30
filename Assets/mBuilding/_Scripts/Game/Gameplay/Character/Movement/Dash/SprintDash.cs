using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    [CreateAssetMenu(fileName = "new SprintDash", menuName = "Ability/Dash/SprintDash")]

    public class SprintDash : DashStrategy
    {

        public float _sprintSpeed = 1.5f;


        public override void DoDash(Transform transform)
        {
            CharacterMovemet characterMovemet = transform.GetComponent<CharacterMovemet>();
            characterMovemet.SetSpeedMultiplier = _sprintSpeed;
            Debug.Log("Sprint");
        }
        public override void StopDash(Transform transform)
        {
            CharacterMovemet characterMovemet = transform.GetComponent<CharacterMovemet>();
            characterMovemet.ResetSpeedMultiplier();
        }
    }
}