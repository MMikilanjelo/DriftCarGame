using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float _moveSmoothness;
    public float _rotationSmoothness;

    public Vector3 _moveOffset;
    public Vector3 _rotationOffset;

    public Transform _targetToFollow;

    void FixedUpdate()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        HandleMovment();
        HandleRotation();
    }
    void HandleMovment()
    {
        Vector3 _targetPosition = new Vector3();
        _targetPosition = _targetToFollow.TransformPoint(_moveOffset);
        transform.position = Vector3.Lerp(transform.position , _targetPosition , _moveSmoothness * Time.deltaTime);
    }
    void HandleRotation()
    {
        var _direction = _targetToFollow.position - transform.position;
        
        var _rotation = Quaternion.LookRotation(_direction + _rotationOffset , Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation  , _rotation , _rotationSmoothness * Time.deltaTime);
    }
}
