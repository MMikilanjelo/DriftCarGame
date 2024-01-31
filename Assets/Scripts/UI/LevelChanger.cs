using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class LevelChanger : MonoBehaviour
{
  [SerializeField] private ScriptableObject[] _lvlScriptableObjects;
  [SerializeField] private LvlDisplay _lvlDisplay;
  private int _currentIndex = 0;
  private void Awake()
  {
    ChangeLevelScriptableObject(0);
  }
  public void ChangeLevelScriptableObject(int _lvlToChangeIndex)
  {
    _currentIndex += _lvlToChangeIndex;
    if(_currentIndex < 0) _currentIndex = _lvlScriptableObjects.Length - 1;
    else if (_currentIndex >  _lvlScriptableObjects.Length - 1 ) _currentIndex = 0;
    if(_lvlDisplay != null) _lvlDisplay.DisplayLvl((Level) _lvlScriptableObjects[_currentIndex]);
  }
    
}
