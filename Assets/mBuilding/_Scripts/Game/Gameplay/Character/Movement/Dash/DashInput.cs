using System;
using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement;
using UnityEngine.InputSystem;
using Zenject;
using mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash;
using UnityEngine;

public class DashInput : IDashInput
{
    IDashStrategy _currentDash;
    private PlayerInput _input;
    private InputAction _dashAction;

    public event Action OnDashAction = delegate{};
    public event Action OnDashActionEnd = delegate{};

    [Inject] 
    public void Constructor(PlayerInput input)
    {
        _input = input;
        _dashAction = _input.PlayerControls.DashAction;
        _dashAction.started += DashAction_started;
        _dashAction.canceled += DashAction_canceled;
    }

    private void DashAction_canceled(InputAction.CallbackContext context)
    {
        OnDashActionEnd?.Invoke();
    }

    private void DashAction_started(InputAction.CallbackContext context)
    {
        OnDashAction?.Invoke();
    }
}
