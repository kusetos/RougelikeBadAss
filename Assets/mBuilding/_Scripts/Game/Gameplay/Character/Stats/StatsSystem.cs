using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class StatsSystem
{
    private CharacterStatManager _characterStatManager;

    private HealthStat _healthStat;
    private ArmorStat _armorStat;
    private SpeedStat _speedStat;
    private EnergyStat _energyStat;
    
    public StatsSystem(CharacterStatManager characterStatManager)
    {
        _characterStatManager = characterStatManager;
    }

}
