using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CarMovmentParameters : ScriptableObject
{    public  float _maxSleepAngle = 120.0f;
    public  float _maxAcceleration = 300f;
    public  float _brakePower = 50000f;
    public float _motorPower = 400f;
}
