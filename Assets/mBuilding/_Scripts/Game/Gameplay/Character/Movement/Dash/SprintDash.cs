using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    public class SprintDash : IDashable
    {

        Vector3 sprintSpeed = new Vector3(1.5f, 0, 0);
        public void Dash(MovementWithDash movement)
        {
            movement.SetSpeedMultiplier = sprintSpeed;
        }
    }
}