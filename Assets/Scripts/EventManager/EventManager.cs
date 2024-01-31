using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventTypes
{
    public enum GameEvents
    {
        BeginDrifting,
        EndOfPlayingTime
        
    }
    public enum DataEvents
    {
        PlayerDataLoaded
    }
}


public static class EventManager<TEventEnum, TEventArgs>
{
    private static Dictionary<TEventEnum, Action<TEventArgs>> eventDictionary = new Dictionary<TEventEnum, Action<TEventArgs>>();

    public static void RegisterEvent(TEventEnum eventType, Action<TEventArgs> eventHandler)
    {
        if(eventType == null)
        {
            return;
        }
        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] = eventHandler;
        }
        else
        {
            eventDictionary[eventType] += eventHandler;
        }
    }

    public static void UnregisterEvent(TEventEnum eventType, Action<TEventArgs> eventHandler)
    {
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] -= eventHandler;
        }
    }

    public static void TriggerEvent(TEventEnum eventType, TEventArgs eventArgs)
    {
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType].Invoke(eventArgs);
        }
    }
}
