using System;
using UnityEngine;

namespace mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash
{

    public interface IDashInput
    {
        public event Action OnDashAction;
        public event Action OnDashActionEnd;
    }
}

