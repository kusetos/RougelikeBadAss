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


    private IMoveInput _input;
    private CharacterController _characterController;

    private PlayerGravity _gravity;
    private MovementWithDash _movement;
    //Change to ScriptableObject

    public Button ForceDashButton; 
    public Button SprintDashButton; 
    public Button SlowDownDashButton; 
    public Button QuickDashButton; 


    [Inject]
    public void Constructor(IMoveInput input, CharacterController characterController, PlayerGravity gravity, MovementWithDash movement)
    {
        _input = input;
        _characterController = characterController;
        _gravity = gravity;
        _movement = movement;

        Debug.Log("Ready to move");
    }
                              
    private void Update()
    {
        Vector3 motion = _movement.MoveUpdate(_input.GetDirection) + _gravity.Velocity * Time.deltaTime;    
        _characterController.Move(motion);
        _gravity.GravityUpdate(_characterController);
    }

    private void FixedUpdate() => UpdateSpeedUI();

    public virtual void UpdateSpeedUI()
    {
        if (_speedText)
        {
            float horizontalMagtitude = new Vector3
                (_movement.MoveUpdate(_input.GetDirection).x
                ,0f
                ,_movement.MoveUpdate(_input.GetDirection).z)
                .magnitude;
            _speedText.text = ((int)(horizontalMagtitude * 1000)).ToString();
        }
    }
/*    [Inject] private JumpDash _jumpDash;
    [Inject] private SprintDash _sprintDash;
    [Inject] private SlowDownDash _slowDownDash;
    [Inject] private QuickDash _quickDash;*/
    public void Initialize()
    {
        _movement.ResetSpeedMultiplier();

        /*        ForceDashButton.onClick.AddListener(delegate { _movement.SwitchDash(_jumpDash); });
                SprintDashButton.onClick.AddListener(delegate { _movement.SwitchDash(_sprintDash); });
                SlowDownDashButton.onClick.AddListener(delegate { _movement.SwitchDash(_slowDownDash); });
                QuickDashButton.onClick.AddListener(delegate { _movement.SwitchDash(_quickDash); });*/
        ForceDashButton.onClick.AddListener(delegate { _movement.SwitchDash(_movement.jumpDash); });
        SprintDashButton.onClick.AddListener(delegate { _movement.SwitchDash(_movement.sprintDash); });
        SlowDownDashButton.onClick.AddListener(delegate { _movement.SwitchDash(_movement.slowDownDash); });
        QuickDashButton.onClick.AddListener(delegate { _movement.SwitchDash(_movement.quickDash); });
        _movement.SwitchDash(_movement.sprintDash);
    }

    public void Dispose()
    {
    }
}
