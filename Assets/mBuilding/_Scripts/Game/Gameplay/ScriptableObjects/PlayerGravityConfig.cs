using System.Collections;
using UnityEngine;

namespace Assets.mBuilding._Scripts.Game.Gameplay.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new PlayerGravity", menuName = "Player Gravity Config")]

    public class PlayerGravityConfig : ScriptableObject
    {
        [Header("Gravity Properties")]
        [SerializeField] private Vector3 _gravityForce;
        [SerializeField] private Vector3 _groundedVelocity;
        [SerializeField] private float _gravityScale;
        
        public Vector3 GravityForce => _gravityForce;
        public Vector3 GroundedVelocity => _groundedVelocity;
        public float GravityScale => _gravityScale;
    }
}