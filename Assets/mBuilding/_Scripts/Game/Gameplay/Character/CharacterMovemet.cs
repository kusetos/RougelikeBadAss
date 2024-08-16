using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class CharacterMovemet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speedText;


    private Camera _cam;
    private PlayerInput _input;
    private InputAction _moveAction;
    private CharacterController _characterController;

    #region Movement
    [Header("Moving Config")]
    [SerializeField] private float _movingSpeed;
    [Range(1f, 20f)][SerializeField] private float _smoothSpeed;
    private Vector3 _inputDir;
    private Vector3 _smoothMovementInput = Vector3.zero;
    //private bool _isMoving = false;
    #endregion
    [SerializeField] private PlayerGravity _gravity;

    [Inject]
    public void Constructor(PlayerInput input, CharacterController characterController)
    {
        _input = input;
        _characterController = characterController;
        _moveAction = _input.PlayerControls.MoveAction;
        Debug.Log("Ready to move");
    }

    private void Update()
    {
        MoveLogic();
        GravityUpdate();
    }

    private void CalculateMovementSmoothing()
    {

        _smoothMovementInput = Vector3.Lerp(_smoothMovementInput, GetDirection, Time.deltaTime * _smoothSpeed);
    }
    private void MoveLogic()
    {

        CalculateMovementSmoothing();
        Vector3 moving = ((_smoothMovementInput * _movingSpeed) + _gravity.Velocity) * Time.deltaTime;

        _characterController.Move(moving);

        if (_smoothMovementInput.magnitude <= 0.001f)
            _smoothMovementInput = Vector3.zero;

    }
    private void UpdateSpeedUI()
    {
        if (_speedText)
            _speedText.text = ((int)(_smoothMovementInput.magnitude * Time.deltaTime * _movingSpeed * 1000)).ToString();
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
    private void GravityUpdate()
    {
        if (!_characterController.isGrounded)
        {
            _gravity.UpdateVelocity();
        }
        else
        {
            _gravity.ResetVelocity();
        }
    }


}
[System.Serializable]
public class PlayerGravity
{
    #region Gravity
    [Header("Gravity Properties")]
    [SerializeField] private Vector3 _gravityForce;
    [SerializeField] private Vector3 _isGroundedVelocity;
    [SerializeField] private float _gravityScale;
    #endregion

    private Vector3 _velocity = Vector3.zero;
    public Vector3 GravityForce => _gravityForce;
    public float GravityScale => _gravityScale;
    public void UpdateVelocity()
    {
        _velocity += _gravityForce * _gravityScale * Time.deltaTime;
    }
    public Vector3 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }
    public void ResetVelocity()
    {
        _velocity = _isGroundedVelocity;
    }
}
