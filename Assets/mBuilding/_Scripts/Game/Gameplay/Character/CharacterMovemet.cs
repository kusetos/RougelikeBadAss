using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement;
using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash;
using mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

public class CharacterMovemet : MonoBehaviour, IDisposable, IInitializable
{
    [SerializeField] private TextMeshProUGUI _speedText;


    private IMoveInput _moveInput;
    private CharacterController _characterController;

    private PlayerGravity _gravity;
    private BaseMovement _movement;

    private IDashInput _dashInput;
    private IDashStrategy _currentDash;
    private float _speedMultiplier = 1f;




    [Inject]
    public void Constructor(IMoveInput input, IDashInput dashInput, CharacterController characterController, PlayerGravity gravity, BaseMovement movement)
    {
        _moveInput = input;
        _dashInput = dashInput;
        _characterController = characterController;
        _gravity = gravity;
        _movement = movement;

        Debug.Log("Ready to move");
    }

    /// --------------------------------------------------------------------------
    public Button SprintDashButton; 
    public Button SlowDownDashButton; 
    public Button QuickDashButton; 


    public SprintDash _sprintDash = new();
    public SlowDownDash _slowDownDash = new();
    public QuickDash _quickDash = new();
    public EmptyDash _emptyDash= new();
    public void SetGravityVel(float vel)
    {
        _gravity.Velocity = new Vector3(0, 2, 0) + _moveInput.GetDirection * vel;
    }

    public void Dispose()
    {
        
    }

    public void Initialize()
    {
        SwitchDash(_emptyDash);
        
        _dashInput.OnDashAction += () => { _currentDash.DoDash(this.transform); };
        _dashInput.OnDashActionEnd += () => { _currentDash.StopDash(this.transform); };

        ResetSpeedMultiplier();

        QuickDashButton.onClick.AddListener(delegate { SwitchDash(_quickDash); });
        SprintDashButton.onClick.AddListener(delegate { SwitchDash(_sprintDash); });
        SlowDownDashButton.onClick.AddListener(delegate { SwitchDash(_slowDownDash); });


    }

    public void SwitchDash(IDashStrategy newDash)
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

    }

    private void FixedUpdate()
    {
        Vector3 motion = _movement.MoveLogic(_moveInput.GetDirection) * _speedMultiplier + _gravity.Velocity * Time.fixedDeltaTime;    
        _characterController.Move(motion);
        _gravity.GravityUpdate(_characterController);
        UpdateSpeedUI();
    } 

    public void UpdateSpeedUI()
    {
        if (_speedText)
        {
            float horizontalMagtitude
                = new Vector3 (_movement.MoveLogic(_moveInput.GetDirection).x, 0f,_movement.MoveLogic(_moveInput.GetDirection).z).magnitude
                * _speedMultiplier;
            _speedText.text = ((int)(horizontalMagtitude * 1000)).ToString();
        }
    }


}
