using UnityEngine;

[CreateAssetMenu(fileName ="new HealthStat", menuName = "Stats/Health Stat")]
public class HealthStat : BaseStat
{
    [SerializeField] private float _hitPoints;
    public float HitPoints => _hitPoints;
}