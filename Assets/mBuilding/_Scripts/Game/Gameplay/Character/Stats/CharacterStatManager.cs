using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class CharacterStatManager : MonoBehaviour
{
    [SerializeField] private List<StatLevels> Stats; 
    [SerializeField] private Transform _container;
    [SerializeField] private StatUI statUIPrefab;
    private int _skillPoints;
    public int SkillPoints => _skillPoints;
    public event Action OnSkillPointsChanged;

public void GainSkillPoints()
{
    _skillPoints++;
    OnSkillPointsChanged?.Invoke();
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
    

}

