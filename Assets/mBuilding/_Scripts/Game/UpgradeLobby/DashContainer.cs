using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.mBuilding._Scripts.Game.UpgradeLobby
{
    public class DashContainer : MonoBehaviour
    {

        [SerializeField] private DashStrategy _dashStrategy;
        [SerializeField] private Toggle _toggle;

        [Inject] private DashManager _dashManager; 

        public DashStrategy Dash => _dashStrategy;
        //public Toggle Toggle => _toggle;

        private void Awake()
        {
            _toggle.onValueChanged.AddListener(ChangeAction);
            ColorBlock cb = _toggle.colors;
            cb.normalColor = Dash.color;
            
        }

        private void ChangeAction(bool value)
        {
            //if (value)
                _dashManager.SwitchDash(Dash);
            
        }
    }
}