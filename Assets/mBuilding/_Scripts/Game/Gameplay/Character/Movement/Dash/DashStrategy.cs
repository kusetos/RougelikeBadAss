using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement
{
    public interface IDashStrategy
    {
        public abstract void DoDash(Transform transform);
        public abstract void StopDash(Transform transform);

    }
}