using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class CharacterStatManager : MonoBehaviour
{
    //[SerializeField] private List<StatLevels> _stats;
    [SerializeField] private StatLevels _healthLevels;
    [SerializeField] private StatLevels _armorLevels;
    [SerializeField] private StatLevels _speedLevels;
    [SerializeField] private StatLevels _energyLevels;

    private int _skillPoints;
    public int SkillPoints => _skillPoints;
    public event Action OnSkillPointsChanged;

    public void GainSkillPoints()
    {
        _skillPoints++;
        OnSkillPointsChanged?.Invoke();
    }
    public bool CanAffordStat(BaseStat stat)
    {
        return stat.CostToUpgrade <= _skillPoints;
    }
    public void UnlockStat(BaseStat stat)
    {
        if (!CanAffordStat(stat)) return;
        _skillPoints -= stat.CostToUpgrade;
    }
    public HealthStat GetCurrentHealthStat()
    {
        //List<BaseStat> HealthLevels = _stats.FirstOrDefault(s => s.Type == StatType.Health).Levels.ToList();
        HealthStat exactHealthStat = _healthLevels.Levels.First(l => l.Index == 1) as HealthStat;
        Debug.Log(exactHealthStat.Name);

        return exactHealthStat;
    }
    private void Start(){
        GetCurrentHealthStat();
    }
}
// I shoul add index for current stats
// private void Start()
// {
//     foreach (var stat in _characterStats)
//      {
//          StatUI statUI = Instantiate(statUIPrefab, _container);
//          statUI._textInfo.text = stat.Stats.Levels[0].Name;
//          statUI._upgradeButton.onClick.AddListener(delegate {OnUpgrade(stat, statUI);});
//      }
// }

// private void OnUpgrade(CharacterStats characterStats, StatUI statUI)
// {
//     statUI._textInfo.text = characterStats.Stats.Levels[1].Name;

// }


