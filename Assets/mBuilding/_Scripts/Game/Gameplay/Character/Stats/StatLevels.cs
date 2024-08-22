using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new StatLevels", menuName = "Stats/StatLevels")]
public class StatLevels : ScriptableObject
{
    [SerializeField] private List<BaseStat> _levels;
    public List<BaseStat> Levels => _levels;
}
