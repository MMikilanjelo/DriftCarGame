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
        

        //Load a scene with information about currency etc and oportunity for doule it by watching video
        //SceneManager.LoadScene("MainMenu");
    }
}
