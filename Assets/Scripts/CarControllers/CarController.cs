using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class CarController : MonoBehaviour
{
    [SerializeField] CarMovmentParameters _carMovmentParameters;
    [SerializeField] PlayerScoresSources _playerScoreSources;
    public enum Axel
    {
        Front ,
        Rear
    };
    [Serializable] 
    public struct Wheel
    {
        public GameObject _wheelEffectObject;
        public GameObject _wheelModel;
        public WheelCollider _wheelCollider;
        public Axel _axel;
    }
    private float _moveInput;
    private float _steerInput;
    private bool _isBraking;
    private Rigidbody _carRigidBody;
    public List<Wheel> _wheels;
    public Vector3 _centerOfMass;
    
    void Start()
    {
        _carRigidBody = GetComponent<Rigidbody>();
        _carRigidBody.centerOfMass = _centerOfMass;
    }
    void FixedUpdate()
    {
        GetInputs();
        AnimateWheels();
        WheelEffects();
    }
    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    private void GetInputs()
    {
        _moveInput = Input.GetAxis("Vertical");
        _steerInput = Input.GetAxis("Horizontal");
        _isBraking = Input.GetKey(KeyCode.Space);
    }
    
    private void Move()
    {
        foreach(var _wheel in _wheels)
        {
           _wheel._wheelCollider.motorTorque = _moveInput * _carMovmentParameters._carSpeed * _carMovmentParameters._maxAcceleration * Time.deltaTime;
        }
    }
    private void Steer()
    {
        foreach(var _wheel in _wheels)
        {
            if(_wheel._axel == Axel.Front)
            {
                var _steerAngle  = _steerInput * _carMovmentParameters._turnSensivity * _carMovmentParameters._maxSteerAngle;
                _wheel._wheelCollider.steerAngle = Mathf.Lerp(_wheel._wheelCollider.steerAngle , _steerAngle , 1f);
                
            }
        }
    }
    private void AnimateWheels()
    {
        foreach(var _wheel in _wheels)
        {
            Quaternion _rotation;
            Vector3 _position;
            _wheel._wheelCollider.GetWorldPose(out _position ,out _rotation);
            _wheel._wheelModel.transform.position = _position;
            _wheel._wheelModel.transform.rotation = _rotation;
        }
    }
    private void Brake()
    {
        if(_isBraking)
        {
            foreach(var _wheel in _wheels)
            {
                _wheel._wheelCollider.brakeTorque = _carMovmentParameters._brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach(var _wheel in _wheels)
            {
                _wheel._wheelCollider.brakeTorque = 0;
            }
        }
    }
    private void WheelEffects()
    {
        foreach(var _wheel in _wheels)
        {
            if(_isBraking && CheckForDrifting(_wheel._wheelCollider.motorTorque))
            {
                _wheel._wheelEffectObject.GetComponentInChildren<TrailRenderer>().emitting = true;
                TriggerDriftingEvent();
            }
            else
            {
               _wheel._wheelEffectObject.GetComponentInChildren<TrailRenderer>().emitting = false; 
            }
        }
    }
    
    private bool CheckForDrifting(float _motorTorque)
    {
        if (Mathf.Abs(_steerInput) >= _carMovmentParameters._driftingThreshold && _motorTorque >= 30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void TriggerDriftingEvent()
    {
        EventManager<EventTypes.GameEvents, int>.TriggerEvent(EventTypes.GameEvents.BeginDrifting , _playerScoreSources._steeringScore);
    }
}
