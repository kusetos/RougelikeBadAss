using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class StatsSetup
{
    public readonly HealthStat HealthStat;
    public readonly ArmorStat ArmorStat;
    public readonly SpeedStat SpeedStat;
    public readonly EnergyStat EnergyStat;
    
    public StatsSetup(HealthStat healthStat, ArmorStat armorStat, SpeedStat speedStat, EnergyStat energyStat)
    {
        HealthStat = healthStat;
        ArmorStat = armorStat;
        SpeedStat = speedStat;
        EnergyStat = energyStat;
    }
}
