using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    //[CreateAssetMenu(fileName = "new SprintDash", menuName = "Movement/Dashes/SprintDash")]

    public class SprintDash : IDashStrategy
    {

        public float _sprintSpeed = 1.5f;


        public void DoDash(Transform transform)
        {
            CharacterMovemet characterMovemet = transform.GetComponent<CharacterMovemet>();
            characterMovemet.SetSpeedMultiplier = _sprintSpeed;
            Debug.Log("Sprint");
        }
        public void StopDash(Transform transform)
        {
            CharacterMovemet characterMovemet = transform.GetComponent<CharacterMovemet>();
            characterMovemet.ResetSpeedMultiplier();
        }
    }
}