using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "New Car" , menuName ="Cars")]
public class Car : ScriptableObject
{
    public string _carName;
    public string _carDescription;
    public GameObject _carModel;
    public CarMovmentParameters _carStats;
}
