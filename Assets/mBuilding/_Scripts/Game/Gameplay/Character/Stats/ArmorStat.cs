using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new ArmorStat", menuName = "Stats/Armor Stat")]
public class ArmorStat : BaseStat
{
    [SerializeField][Range(0f, 1f)] private float _armor;
    public float Armor => _armor; 
}
