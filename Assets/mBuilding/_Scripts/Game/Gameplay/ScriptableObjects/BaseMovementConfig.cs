using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new BaseMovementConfig", menuName = "Base Movement Config")]
public class BaseMovementConfig : ScriptableObject
{
    [SerializeField] private float _movingSpeed;

    [Range(1f, 20f)][SerializeField] private float _speedSmoothing; 
    public float MovingSpeed => _movingSpeed;
    public float SpeedSmoothing => _speedSmoothing;
}
