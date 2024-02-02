using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChanger : MonoBehaviour
{
  [SerializeField] private Car[] _carScriptableObjects;
  [SerializeField] private CarDisplay _carDisplay;
  private int _currentIndex = 0;
  private void Start()
  {
     ChangeCarScriptableObject(0);
  }
  public void ChangeCarScriptableObject(int _carToChangeIndex)
  {
    _currentIndex += _carToChangeIndex;
    if(_currentIndex < 0) _currentIndex = _carScriptableObjects.Length - 1;
    
    else if (_currentIndex >  _carScriptableObjects.Length - 1 ) _currentIndex = 0;
    
    if(_carDisplay != null) _carDisplay.DisplayCar(_carScriptableObjects[_currentIndex]);
  }
}
