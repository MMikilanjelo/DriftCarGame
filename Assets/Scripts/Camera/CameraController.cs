using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoCashe
{
    CinemachineVirtualCamera _cinemachineVirtualCamera;
   private void Awake()
   {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        EventManager<EventTypes.GameEvents , SpawnData >.RegisterEvent(EventTypes.GameEvents.LevelStarted  , OnLvlStarted);
   }
   private void OnLvlStarted(SpawnData _spawnData)
   {
        if(_cinemachineVirtualCamera == null) return;
        _cinemachineVirtualCamera.Follow = _spawnData._cameraFollowPointTransform;
        _cinemachineVirtualCamera.LookAt = _spawnData._playerTransform;
   }
   private void OnDestroy()
   {
         EventManager<EventTypes.GameEvents , SpawnData >.UnregisterEvent(EventTypes.GameEvents.LevelStarted  , OnLvlStarted);
   }
}

