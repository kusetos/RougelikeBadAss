using Assets.mBuilding._Scripts.Game.Gameplay.ScriptableObjects;
using UnityEngine;

[System.Serializable]
public class PlayerGravity
{
    #region fields
    private Vector3 _gravityForce;
    private Vector3 _groundedVelocity;
    private float _gravityScale;
    #endregion

    public PlayerGravity(PlayerGravityConfig config)
    {
        _gravityForce = config.GravityForce;
        _gravityScale = config.GravityScale;
        _groundedVelocity = config.GroundedVelocity;
        
    }

    private Vector3 _velocity = Vector3.zero;
    public Vector3 GravityForce => _gravityForce;
    public float GravityScale => _gravityScale;
    public void UpdateVelocity()
    {
        _velocity += _gravityForce * _gravityScale * Time.fixedDeltaTime;
    }
    public Vector3 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }
    public void ResetVelocity()
    {
        _velocity = _groundedVelocity;
    }
    public void GravityUpdate(CharacterController characterController)
    {
        if (!characterController.isGrounded)
        {

            UpdateVelocity();
        }
        else
        {
            ResetVelocity();
        }
    }
}
