using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerSpawnNotifier : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Transform _cameraFollowPointTransform;
    private PhotonView _photonView;
    void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }
    void Start()
    {
        if(!_photonView.IsMine) return;
        EventManager<EventTypes.GameEvents , SpawnData >.TriggerEvent(EventTypes.GameEvents.LevelStarted  , new SpawnData
        {
            _playerTransform = _playerTransform,
            _cameraFollowPointTransform = _cameraFollowPointTransform
        });
    }
    }
[System.Serializable]
public class SpawnData
{
    public Transform _cameraFollowPointTransform;
    public Transform _playerTransform;
}
