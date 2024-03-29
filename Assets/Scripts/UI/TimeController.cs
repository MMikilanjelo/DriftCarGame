using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoCashe
{
  
    [SerializeField] Text _timeText;
    [SerializeField] float _remainingTime;
    public override void OnTick()
    {
        HandleRemainingTime();
    }
    void HandleRemainingTime()
    {
        if(_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
        }
        else if(_remainingTime < 0)
        {
            _remainingTime = 0;
            EventManager<EventTypes.GameEvents, float>.TriggerEvent(EventTypes.GameEvents.EndOfPlayingTime , _remainingTime);
        }
        int _remainingMinuters = Mathf.FloorToInt(_remainingTime / 60);
        int _remainingSeconds = Mathf.FloorToInt(_remainingTime % 60);
        _timeText.text = string.Format("{0:00}:{1:00}" , _remainingMinuters , _remainingSeconds);
    }
}
