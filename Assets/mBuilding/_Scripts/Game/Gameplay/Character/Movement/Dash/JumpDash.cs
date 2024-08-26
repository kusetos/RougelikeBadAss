using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{
    public class EmptyDash : IDashStrategy
    {
        public void DoDash(Transform movement){}
        public void StopDash(Transform transform){}
    }
}