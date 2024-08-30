using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableDash : ScriptableObject
{
    [SerializeField] private DashStrategy _dash;
    public DashStrategy Dash => _dash;

    
}
