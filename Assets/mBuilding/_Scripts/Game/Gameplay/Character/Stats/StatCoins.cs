using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatCoins : MonoBehaviour
{

    private int _statPoints;
    public int StatPoints => _statPoints;
    public event Action OnSkillPointsChanged;

    #region statPoints
    [SerializeField] TextMeshProUGUI _statPointsText;
    [SerializeField] private Button _pointsButton;
    #endregion

    public void GainSkillPoints()
    {
        _statPoints++;
        OnSkillPointsChanged?.Invoke();
    }
    public bool CanAffordStat(BaseStat stat)
    {
        return stat.CostToUpgrade <= _statPoints;
    }
    public void UnlockStat(BaseStat stat)
    {
        if (!CanAffordStat(stat)) return;
        _statPoints -= stat.CostToUpgrade;
    }
}
