using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (fileName = "SimpleCarFactory" , menuName ="CarFactory")]
public class CarFactory : ScriptableObject
{
    public Dictionary<CarModel , GameObject> _carGameObjects = new Dictionary<CarModel, GameObject>();
    public List<Car> _cars;
    public void InitializeFactory()
    {
        foreach(var car in _cars)
        {
            Debug.Log(car._carPrefab);
            _carGameObjects.Add(car._carModel , car._carPrefab);
        }
    }
    public GameObject GetCar(CarModel _carModel )
    {
        if (_carGameObjects.TryGetValue(_carModel, out GameObject carPrefab))
        {
            return carPrefab;
        }
        else
        {
            Debug.LogWarning("Prefab not found for car model: " + _carModel);
            return null;
        }
    }
}
