using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[System.Serializable]
public class CharacterStatSystem
{
    private StatContainer _healthContainer;
    private StatContainer _armorContainer;
    private StatContainer _speedContainer;
    private StatContainer _energyContainer;

    public CharacterStatSystem(
        [Inject(Id = "Health")] StatContainer health,
        [Inject(Id = "Armor")] StatContainer armor,
        [Inject(Id = "Speed")] StatContainer speed,
        [Inject(Id = "Energy")] StatContainer energy)
    {
        _healthContainer = health;
        _armorContainer = armor;
        _speedContainer = speed;
        _energyContainer = energy;

    }

    public StatsSetup GenerateStatSetup()
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