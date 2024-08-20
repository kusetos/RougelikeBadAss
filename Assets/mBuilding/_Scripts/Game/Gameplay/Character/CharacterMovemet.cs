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
    private BaseMovement _movement;

    private DashStrategy _currentDash;
    private float _speedMultiplier = 1f;




    [Inject]
    public void Constructor(IMoveInput input, CharacterController characterController, PlayerGravity gravity, BaseMovement movement)
    {
        _input = input;
        _characterController = characterController;
        _gravity = gravity;
        _movement = movement;

        Debug.Log("Ready to move");
    }

    /// --------------------------------------------------------------------------
    public Button SprintDashButton; 
    public Button SlowDownDashButton; 
    public Button QuickDashButton; 

    public SprintDash _sprintDash;
    public SlowDownDash _slowDownDash;
    public QuickDash _quickDash;
    public void SetGravityVel(float vel)
    {
        _gravity.Velocity = new Vector3(0, 2, 0) + _input.GetDirection * vel;
    }

    public void Dispose()
    {
        
    }

    public void Initialize()
    {
        _input.DashAction += () => { _currentDash.DoDash(this.transform); };
        _input.StopDashAction += () => { _currentDash.StopDash(this.transform); };

        ResetSpeedMultiplier();

        QuickDashButton.onClick.AddListener(delegate { SwitchDash(_quickDash); });
        SprintDashButton.onClick.AddListener(delegate { SwitchDash(_sprintDash); });
        SlowDownDashButton.onClick.AddListener(delegate { SwitchDash(_slowDownDash); });

        SwitchDash(_slowDownDash);

    }

    public void SwitchDash(DashStrategy newDash)
    {
        ResetSpeedMultiplier();
        if (newDash == _currentDash) return;

        Debug.Log("Switch DASH");
        _currentDash = newDash;
    }
    public float SetSpeedMultiplier { set { _speedMultiplier = value; } }
    public void ResetSpeedMultiplier() => _speedMultiplier = 1f;

    /// _------------------------------------------------------------------------
    private void Update()
    {
        Vector3 motion = _movement.MoveUpdate(_input.GetDirection) * _speedMultiplier + _gravity.Velocity * Time.deltaTime;    
        _characterController.Move(motion);
        _gravity.GravityUpdate(_characterController);
    }

    private void FixedUpdate() => UpdateSpeedUI();

    public void UpdateSpeedUI()
    {
        if (_speedText)
        {
            float horizontalMagtitude
                = new Vector3 (_movement.MoveUpdate(_input.GetDirection).x, 0f,_movement.MoveUpdate(_input.GetDirection).z).magnitude
                * _speedMultiplier;
            _speedText.text = ((int)(horizontalMagtitude * 1000)).ToString();
        }
    }


}
