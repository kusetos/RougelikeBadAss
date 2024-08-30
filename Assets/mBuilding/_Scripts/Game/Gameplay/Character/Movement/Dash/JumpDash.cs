using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    public class EmptyDash : DashStrategy
    {
        public override void DoDash(Transform movement){}
        public override void StopDash(Transform transform){}
    }
}