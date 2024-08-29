using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatCoins : MonoBehaviour
{

    private int _statPoints;
    public int StatPoints => _statPoints;
    public event Action OnSkillPointsChanged;

}
