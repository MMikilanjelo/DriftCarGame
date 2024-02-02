using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Test : MonoBehaviour
{
    public GameObject _playerToSpawnPrefab;

    private void Start()
    {
        EventManager<EventTypes.GameEvents , Transform>.TriggerEvent(EventTypes.GameEvents.LevelStarted , transform);
    }   
}
