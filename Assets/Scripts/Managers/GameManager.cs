using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Awake()
    {
        RegisterEvents();
    }   
    private void RegisterEvents()
    {
        EventManager<EventTypes.GameEvents , float>.RegisterEvent(EventTypes.GameEvents.EndOfPlayingTime , FinishGame);
    }
    private void FinishGame(float _totalGameTime)
    {
        SaveManager._saveMangerInstance?.Save();
        SceneManager.LoadScene("MainMenu");
    }
    private void OnDestroy()
    {
        EventManager<EventTypes.GameEvents , float>.UnregisterEvent(EventTypes.GameEvents.EndOfPlayingTime , FinishGame);
    }
}
