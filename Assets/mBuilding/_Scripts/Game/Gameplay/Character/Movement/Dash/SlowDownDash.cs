using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    //[CreateAssetMenu(fileName = "new SlowDownDash", menuName = "Movement/Dashes/SlowDash") ]
    public class SlowDownDash : IDashStrategy
    {
        public float _slowMultiplier = 0.7f;
        

        public void DoDash(Transform transform)
        {
            CharacterMovemet characterMovemet = transform.GetComponent<CharacterMovemet>();
            characterMovemet.SetSpeedMultiplier = _slowMultiplier;
            Debug.Log("Slowing down");
        }

        public void StopDash(Transform transform)
        {
            CharacterMovemet characterMovemet = transform.GetComponent<CharacterMovemet>();
            characterMovemet.ResetSpeedMultiplier();
        }
    }
}