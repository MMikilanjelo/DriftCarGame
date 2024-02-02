using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovmentButtons : MonoBehaviour
{

    public bool _isPressed;      

    public float _dampenPress = 0;   
    public float _sensitivity = 2f; 
    void Start()
    {
        SetUpButton();              
    }
    void Update()
    {
                                    
        if (_isPressed)
        {
            _dampenPress += _sensitivity * Time.deltaTime;
        }
        else
        {
            _dampenPress -= _sensitivity * Time.deltaTime;
            
        }
        _dampenPress = Mathf.Clamp01(_dampenPress);

    }
    void SetUpButton()
    {
       
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        
       
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => onClickDown());
        
        
        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((e) => onClickUp());

       
        trigger.triggers.Add(pointerDown);
        trigger.triggers.Add(pointerUp);


    }

    public void onClickDown()
    {
        _isPressed = true;
    }

    public void onClickUp()
    {
        _isPressed = false;
    }
}

