using UnityEngine;

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
