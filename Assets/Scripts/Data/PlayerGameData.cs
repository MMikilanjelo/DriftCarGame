using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class PlayerGameData 
{
    public int _currency;
    public List<CarModel> _unlockedCars;

    public PlayerGameData()
    {
        _unlockedCars = new List<CarModel>();
        _currency = 0;
    }
}
