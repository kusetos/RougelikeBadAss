using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement
{

    public abstract class DashStrategy : ScriptableObject
    {
        public Color color;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        public Sprite Icon => _icon;
        public string Name => _name;
        public string Description => _description;
        public abstract void DoDash(Transform transform);
        public abstract void StopDash(Transform transform);

    }
}