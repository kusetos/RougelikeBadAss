using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[CreateAssetMenu(fileName ="new ArmorStat", menuName = "Stats/Armor Stat")]
public class ArmorStat : BaseStat
{
    public override float Value => base.Value / 100f;
}
