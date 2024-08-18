using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement;
using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

public class CharacterMovemet : MonoBehaviour, IDisposable, IInitializable
{
    [SerializeField] private TextMeshProUGUI _speedText;


    private Camera _cam;
    private PlayerInput _input;
    private InputAction _moveAction, _dashAction;
    private CharacterController _characterController;

    private PlayerGravity _gravity;
    private MovementWithDash _movement;
    //Change to ScriptableObject

    public Button ForceDashButton; 
    public Button SprintDashButton; 
    public Button SlowDownDashButton; 


    [Inject]
    public void Constructor(PlayerInput input, CharacterController characterController, PlayerGravity gravity, MovementWithDash movement)
    {
        _input = input;
        _characterController = characterController;
        _gravity = gravity;
        _movement = movement;

        Debug.Log("Ready to move");
    }
    public void OnEnable()
    {
        _moveAction = _input.PlayerControls.MoveAction;

        _dashAction = _input.PlayerControls.DashAction;
        _dashAction.performed += _dashAction_performed;
        _dashAction.canceled += _dashAction_canceled;

        _movement.ResetSpeedMultiplier();
    }

    private void _dashAction_canceled(InputAction.CallbackContext obj)
    {
        _movement.ResetSpeedMultiplier();
    }

    private void _dashAction_performed(InputAction.CallbackContext obj)
    {
        _movement.DoDash();
        Debug.Log("Dash");
    }
                                        
    private void Update()
    {
        _characterController.Move(_movement.MoveUpdate(GetDirection));
        _gravity.GravityUpdate(_characterController);
    }

    private void FixedUpdate() => UpdateSpeedUI();

    public Vector3 GetDirection
    {
        get
        {
            Vector2 inputMovement = _moveAction.ReadValue<Vector2>();
            return new Vector3(inputMovement.x, 0, inputMovement.y);
        }
    }
    public virtual void UpdateSpeedUI()
    {
        if (_speedText)
        {
            float horizontalMagtitude = new Vector3
                (_movement.MoveUpdate(GetDirection).x
                ,0f
                ,_movement.MoveUpdate(GetDirection).z)
                .magnitude;
            _speedText.text = ((int)(horizontalMagtitude * 1000)).ToString();
        }
    }

    public void Dispose()
    {
        _dashAction.performed -= _dashAction_performed;
        _dashAction.canceled -= _dashAction_canceled;
    }

    public void Initialize()
    {
        ForceDashButton.onClick.AddListener(_movement.SwitchDash(new ForceDash()));
    }
}
