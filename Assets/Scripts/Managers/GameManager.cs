using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarFactory _carFactory;
    public static GameManager _gameManagerInstance {get ; private set;}
    private void Awake()
    {
        if(_gameManagerInstance != null && _gameManagerInstance != this)
        {
            Destroy (gameObject);
        }
        else
        {
            _gameManagerInstance = this;
        }
        DontDestroyOnLoad(gameObject);
        RegisterEvents();
        _carFactory.InitializeFactory();
        Debug.Log(Application.persistentDataPath);
    }
   
    public void RegisterEvents()
    {
        EventManager<EventTypes.GameEvents , float>.RegisterEvent(EventTypes.GameEvents.EndOfPlayingTime , FinishGame);
        EventManager<EventTypes.GameEvents , Transform>.RegisterEvent(EventTypes.GameEvents.LevelStarted , OnLvlStarted);
    }
    private void FinishGame(float _totalGameTime)
    {
        //TODO: Add ads from iron source
        //SceneManager.LoadScene("MainMenu");
    }


    private void OnLvlStarted(Transform _transform)
    {
        //PhotonNetwork.OfflineMode = true;
        var _carPrefab = _carFactory.GetCar(CarModel.Bugati);
        PhotonNetwork.Instantiate(_carPrefab.name , new Vector3(-2 , 1 , 8 ) , Quaternion.identity);
    }
    private void OnDestroy()
    {
        EventManager<EventTypes.GameEvents , float>.UnregisterEvent(EventTypes.GameEvents.EndOfPlayingTime , FinishGame);
        EventManager<EventTypes.GameEvents , Transform>.UnregisterEvent(EventTypes.GameEvents.LevelStarted , OnLvlStarted);
    }
}
