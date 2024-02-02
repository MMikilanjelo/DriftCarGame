using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
public class CarMovementController : MonoCashe
{

    public CarMovmentParameters _carParameters;
    private Rigidbody _playerRB;
    public WheelColliders _colliders;
    public WheelMeshes _wheelMeshes;
    private Vector3 _movementInput;
    private  float _motorPower => _carParameters._motorPower;
    private float _brakePower => _carParameters._brakePower;
    private float _maxSleepAngle => _carParameters._maxSleepAngle;
    private float _speed;
    private float _slipAngle;
    float _brakeInput;
    public AnimationCurve _steeringCurve;
    private PhotonView _photonView;

    void Awake()
    {
        
        _photonView = GetComponent<PhotonView>();
        AddFixedUpdate();
        _playerRB = gameObject.GetComponent<Rigidbody>();
        Debug.Log(_photonView.IsMine);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if(!_photonView.IsMine) return;
        _movementInput = context.ReadValue<Vector3>();
    }
    public override void OnTick()
    {
        if(!_photonView.IsMine ) return;
        
        _speed = _playerRB.velocity.magnitude;
        CheckInput();
        ApplyWheelPositions();
        

    }
    public override void OnFixedTick()
    {
        if(!_photonView.IsMine) return;
        ApplyMotor();
        ApplySteering();
        ApplyBrake();
    }



    void CheckInput()
    {
        _slipAngle = Vector3.Angle(transform.forward, _playerRB.velocity - transform.forward);

        float movingDirection = Vector3.Dot(transform.forward, _playerRB.velocity);
        CalculateBrakeInput(movingDirection);
    }
    void CalculateBrakeInput(float movingDirection)
    {
        if (movingDirection < -0.5f && _movementInput.z > 0)
        {
            _brakeInput = Mathf.Abs(_movementInput.z);
        }
        else if (movingDirection > 0.5f && _movementInput.z <= 0)
        {
            _brakeInput = Mathf.Abs(_movementInput.z);
        }
        else
        {
            _brakeInput = 0;
        }
    }
    void ApplyBrake()
    {
        _colliders.FRWheel.brakeTorque = _brakeInput * _brakePower * 0.7f;
        _colliders.FLWheel.brakeTorque = _brakeInput * _brakePower * 0.7f;
        _colliders.RRWheel.brakeTorque = _brakeInput * _brakePower * 0.3f;
        _colliders.RLWheel.brakeTorque = _brakeInput * _brakePower * 0.3f;
    }



    void ApplyMotor()
    {
        _colliders.RRWheel.motorTorque = _motorPower * _movementInput.z;
        _colliders.RLWheel.motorTorque = _motorPower * _movementInput.z;
    }

    void ApplySteering()
    {
        float steeringAngle = _movementInput.x * _steeringCurve.Evaluate(_speed);
        if (_slipAngle < _maxSleepAngle)
        {
            
            steeringAngle += Vector3.SignedAngle(transform.forward, _playerRB.velocity + transform.forward, Vector3.up);
        }
        steeringAngle = Mathf.Clamp(steeringAngle, -90f, 90f);
        _colliders.FRWheel.steerAngle = steeringAngle;
        _colliders.FLWheel.steerAngle = steeringAngle;
    }

    void ApplyWheelPositions()
    {
        UpdateWheel(_colliders.FRWheel, _wheelMeshes.FRWheel);
        UpdateWheel(_colliders.FLWheel, _wheelMeshes.FLWheel);
        UpdateWheel(_colliders.RRWheel, _wheelMeshes.RRWheel);
        UpdateWheel(_colliders.RLWheel, _wheelMeshes.RLWheel);
    }

    void UpdateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
        Quaternion quat;
        Vector3 position;
        coll.GetWorldPose(out position, out quat);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;
    }
}

[System.Serializable]
public class WheelColliders
{
    public WheelCollider FRWheel;
    public WheelCollider FLWheel;
    public WheelCollider RRWheel;
    public WheelCollider RLWheel;
}

[System.Serializable ]
public class WheelMeshes
{
    public MeshRenderer FRWheel;
    public MeshRenderer FLWheel;
    public MeshRenderer RRWheel;
    public MeshRenderer RLWheel;
}