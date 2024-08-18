using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement
{
    public interface IDashable
    {
        public void Dash(MovementWithDash movement);
    }
}