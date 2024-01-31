using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using Unity.VisualScripting;
public class ScoreController : MonoBehaviour
{
    Text _scoreText;
    private int _currentSteeringScore = 0;
    void Awake()
    {
        _scoreText = GetComponent<Text>();
    }
    void Start()
    {
        _scoreText.text = "";
        RegisterEvents();
    }
    private void RegisterEvents()
    {
        EventManager<EventTypes.GameEvents , int>.RegisterEvent(EventTypes.GameEvents.BeginDrifting , OnSteering);
        EventManager<EventTypes.GameEvents , int>.RegisterEvent(EventTypes.GameEvents.EndOfPlayingTime , OnEndOfPlayingTime);
    }

    private void OnSteering(int _steeringScoreToAdd)
    {
        _currentSteeringScore += _steeringScoreToAdd;
        _scoreText.text = _currentSteeringScore.ToString();
    }
    private void OnEndOfPlayingTime(int _value)
    {

    }
    private void OnDestroy()
    {
        EventManager<EventTypes.GameEvents , int>.UnregisterEvent(EventTypes.GameEvents.BeginDrifting , OnSteering);
        EventManager<EventTypes.GameEvents , int>.UnregisterEvent(EventTypes.GameEvents.EndOfPlayingTime , OnEndOfPlayingTime);
    }
}
