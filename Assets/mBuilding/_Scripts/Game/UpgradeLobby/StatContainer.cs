using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatContainer : MonoBehaviour
{
    [SerializeField] private List<BaseStat> _levels;
    [SerializeField] private TextMeshProUGUI _description;

    [SerializeField] private Button _increaseButton;
    [SerializeField] private Button _decreaseButton;

    private int _currentStatLevel = 0;
    private BaseStat _currentStat;

    private void OnEnable()
    {
    }
    private void Awake()
    {
        _currentStatLevel = 0;
        UpdateUI();
        _increaseButton.onClick.AddListener(IncreaseStat);
        _decreaseButton.onClick.AddListener(DecreaseStat);

    }

    private void IncreaseStat()
    {
        if (_currentStatLevel == _levels.Count-1) return;

        _currentStatLevel += 1;
        UpdateUI();
        
    }
    private void DecreaseStat()
    {
        if (_currentStatLevel == 0) return;

        _currentStatLevel -= 1;
        UpdateUI();

    }
    private void UpdateUI()
    {
        _currentStat = _levels.FirstOrDefault(stat => stat.Index == _currentStatLevel);
        _description.text = _currentStat.Name;
    }
    public BaseStat GetCurrentStat
    {
        get
        {
            return _currentStat;
        }
    }
}
