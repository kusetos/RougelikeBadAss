using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpgradeLobbyRootBinder : MonoBehaviour
{
    public GameObject statWindow;
    public GameObject weaponWindow;
    public GameObject abilityWindow;
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
        HandleOpenMainWindow();
    }
}
