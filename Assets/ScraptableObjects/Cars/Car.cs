using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu (fileName = "New Car" , menuName ="Cars")]
public class Car : ScriptableObject
{
    public string _carName;
    public string _carDescription;
    public int _carPrice;
    public CarModel _carModel;
    public GameObject _carGameObject;
    public CarMovmentParameters _carStats;
    public GameObject _carPrefab;

}
