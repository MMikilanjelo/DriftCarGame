using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using Unity.VisualScripting;
public class StatisticController : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    private int _currentSteeringScore = 0;
    void Awake()
    {
        ResetUIElements();
        RegisterEvents();
    }
    private void RegisterEvents()
    {
        EventManager<EventTypes.GameEvents , int>.RegisterEvent(EventTypes.GameEvents.BeginDrifting , OnSteering);
    }
    private void ResetUIElements()
    {
        _scoreText.text = _currentSteeringScore.ToString();
    }
    private void OnSteering(int _steeringScoreToAdd)
    {
        _currentSteeringScore += _steeringScoreToAdd;
        _scoreText.text = _currentSteeringScore.ToString();
    }
}
