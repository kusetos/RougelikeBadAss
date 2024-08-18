using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    public class ForceDash : IDashable
    {
        [Inject]
        CharacterController _character;
        void IDashable.Dash(MovementWithDash movement)
        {
              
        }
    }
}