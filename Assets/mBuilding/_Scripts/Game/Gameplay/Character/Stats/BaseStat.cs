using UnityEngine;

[System.Serializable]
public class BaseStat : ScriptableObject
{
    [SerializeField] private string _statInfo;
    public string StatInfo => _statInfo;
}