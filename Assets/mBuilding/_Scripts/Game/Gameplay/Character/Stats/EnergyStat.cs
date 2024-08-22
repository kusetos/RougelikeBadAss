using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new EnergyStat", menuName = "Stats/Energy Stat")]
public class EnergyStat : BaseStat
{
    [SerializeField] private float _energy;
    public float Energy => _energy;
}
