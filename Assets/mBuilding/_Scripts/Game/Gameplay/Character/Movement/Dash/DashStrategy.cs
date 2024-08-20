using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement
{
    public abstract class DashStrategy : ScriptableObject
    {
        public abstract void DoDash(Transform transform);
        public abstract void StopDash(Transform transform);

    }
}