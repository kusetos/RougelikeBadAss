using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash;
using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement;
using mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.mBuilding._Scripts.Game.UpgradeLobby;
using System;
using TMPro;

public class DashManager : MonoBehaviour
{
    //[SerializeField] private List<DashContainer> _dashList;
    private DashStrategy _selectedDash;

    [SerializeField] private Image _selectedIcon;
    [SerializeField] private TextMeshProUGUI _describtion;

    private void Start()
    {
        //SwitchDash(_dashList[0].Dash);

    }



    public void SwitchDash(DashStrategy newDash)
    {
        //ResetSpeedMultiplier();
        if (newDash == _selectedDash) return;

        //Debug.Log("Switch DASH");
        _selectedDash = newDash;
        //_selectedIcon.sprite = newDash.Icon;
        _selectedIcon.color = Color.blue;
        _describtion.text = newDash.Description;
        Debug.Log($"Current Dash ~~ {_selectedDash.ToString()}");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
        }

    }
}
