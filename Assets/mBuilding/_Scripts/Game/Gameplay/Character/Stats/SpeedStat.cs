using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new SpeedStat", menuName = "Stats/Speed Stat")]

public class SpeedStat : BaseStat
{
    [SerializeField] private float _speed;
    public float Speed => _speed;
}
