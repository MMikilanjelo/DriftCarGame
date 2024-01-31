using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CarMovmentParameters : ScriptableObject
{
    public  float _turnSensivity = 1.0f;
    public  float _maxSteerAngle = 30.0f;
    public  float _maxAcceleration = 300f;
    public  float _brakeAcceleration = 500f;
    public float _damping = 1f;
    public float _carSpeed = 600f;
    public float _driftingThreshold = 0.3f;
}
