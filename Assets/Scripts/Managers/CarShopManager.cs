using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarShopManager : MonoBehaviour
{
    private Car _selectedCar = null;
    public static CarShopManager _carShopInstance {get ; private set;}
    private void Awake()
    {
        if(_carShopInstance != null && _carShopInstance != this)
        {
            Destroy (gameObject);
        }
        else
        {
            _carShopInstance = this;
        }
        DontDestroyOnLoad(gameObject);
        RegisterEvents();
    }
    private void RegisterEvents()
    {
        EventManager<EventTypes.CarShopEvents , Car>.RegisterEvent(EventTypes.CarShopEvents.CarUnlocked , OnCarUnlocked);
        EventManager<EventTypes.CarShopEvents , Car>.RegisterEvent(EventTypes.CarShopEvents.CarSelected , OnCarSelected);
    }
    private void OnCarUnlocked(Car _unlockedCar)
    {   
        PlayerGameData _playerData = SaveManager.Load();
        if(!_playerData._unlockedCars.Contains(_unlockedCar._carModel))
        {
            _playerData._unlockedCars.Add(_unlockedCar._carModel);
            SaveManager.Save(_playerData);
        }
    }
    private void OnCarSelected(Car _selectedCar)
    {
        if(this._selectedCar == _selectedCar)
        {
            EventManager<EventTypes.CarShopEvents , bool>.TriggerEvent(EventTypes.CarShopEvents.CarSelected , true);
        }
        this._selectedCar = _selectedCar;
        
        
    }
    private void OnDestroy()
    {
        EventManager<EventTypes.CarShopEvents , Car>.UnregisterEvent(EventTypes.CarShopEvents.CarUnlocked , OnCarUnlocked);
        EventManager<EventTypes.CarShopEvents , Car>.UnregisterEvent(EventTypes.CarShopEvents.CarSelected , OnCarSelected);
    }
    public Car GetSelectedCar(){
        return _selectedCar;
    }
}
