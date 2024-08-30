using R3;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UIUpgradeLobbyRootBinder : MonoBehaviour
{
    public GameObject statWindow;
    public GameObject weaponWindow;
    public GameObject abilityWindow;
    [Inject] private StatCoin _statCoin;

    [SerializeField] private TextMeshProUGUI _coinText;

    public void UpdateCoins()
    {
        _coinText.text = $"${_statCoin.Count}";
    }
    public void HandleOpenStatModify()
    {
        statWindow.SetActive(true);
    }
    public void HandleOpenWeaponWindow()
    {
        weaponWindow.SetActive(true);
    }
    public void HandleOpenAbilityWindow()
    {
        abilityWindow.SetActive(true);
    }
    public void HandleOpenMainWindow(){
        statWindow.SetActive(false);
        weaponWindow.SetActive(false);
        abilityWindow.SetActive(false);
    }
    private void Start()
    {
        UpdateCoins();
        _statCoin.OnStatPointsChanged += UpdateCoins;

        HandleOpenMainWindow();
    }
}
