using UnityEngine;

[System.Serializable]
public class CharacterStats
{  
    [SerializeField] private StatLevels _statLevels;
    [SerializeField] private StatType _type;
    public StatLevels Stats => _statLevels;
    public StatType Type => _type;

}
