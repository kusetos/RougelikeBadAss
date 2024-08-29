using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterStatSystem : MonoBehaviour
{
    [SerializeField] private StatContainer _healthContainer;
    [SerializeField] private StatContainer _armorContainer;
    [SerializeField] private StatContainer _speedContainer;
    [SerializeField] private StatContainer _energyContainer;

    private StatsSetup GenerateStatSetup()
    {
        HealthStat health = _healthContainer.GetCurrentStat as HealthStat;
        ArmorStat armor = _armorContainer.GetCurrentStat as ArmorStat;
        SpeedStat speed = _speedContainer.GetCurrentStat as SpeedStat;
        EnergyStat energy = _energyContainer.GetCurrentStat as EnergyStat;
        Debug.Log($"{health.Name}, {armor.Name}, {speed.Name}, {energy.Name}");

        StatsSetup stats = new StatsSetup(health, armor, speed, energy);
        return stats;
    }
}
/*public static class StatIdx
{
    public const string HEALTH = "HEALTH";
}


*/