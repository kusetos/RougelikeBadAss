using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatCoin
{

    private int _maxCount;
    private int _count;
    public int Count => _count ;
    public event Action OnStatPointsChanged;

    public StatCoin(int maxCount)
    {
        _maxCount = maxCount;
        _count = _maxCount;
    }

    public bool TryBuyStat()
    {
        if (_count > 0)
        {
            _count--;

            OnStatPointsChanged?.Invoke();

            return true;
        }
        return false;
    }
    public bool TrySellStat()
    {

        if (_count < _maxCount)
        {
            _count++;
            OnStatPointsChanged?.Invoke();
            return true;
        }
        return false;
    }

}
