using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public GameObject _playerToSpawnPrefab;

    private void Awake()
    {
        //Instantiate(_playerToSpawnPrefab , new Vector3(-2 , 1 , 8 ) , Quaternion.identity);
        PhotonNetwork.Instantiate(_playerToSpawnPrefab.name , new Vector3(-2 , 1 , 8 ) , Quaternion.identity);
    }
}
