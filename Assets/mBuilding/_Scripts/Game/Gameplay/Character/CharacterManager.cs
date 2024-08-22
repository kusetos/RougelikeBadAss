using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<CharacterStats> _characterStats; 
    [SerializeField] private Transform _container;
    [SerializeField] private StatUI statUIPrefab;
// I shoul add index for current stats
    private void Start()
    {
        foreach (var stat in _characterStats)
         {
             StatUI statUI = Instantiate(statUIPrefab, _container);
             statUI._textInfo.text = stat.Stats.Levels[0].StatInfo;
             statUI._upgradeButton.onClick.AddListener(delegate {OnUpgrade(stat, statUI);});
         }
    }

    private void OnUpgrade(CharacterStats characterStats, StatUI statUI)
    {
        statUI._textInfo.text = characterStats.Stats.Levels[1].StatInfo;

    }
}
