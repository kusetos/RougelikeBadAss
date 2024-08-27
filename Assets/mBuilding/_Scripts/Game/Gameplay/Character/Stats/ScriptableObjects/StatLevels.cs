using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "new StatLevels", menuName = "Stats/StatLevels")]
public class StatLevels : ScriptableObject
{
    [SerializeField] private List<BaseStat> _levels;
    [SerializeField] private StatType _type;
    public StatType Type => _type;
    public List<BaseStat> Levels => _levels;
    public bool IsPercent = false;
}
