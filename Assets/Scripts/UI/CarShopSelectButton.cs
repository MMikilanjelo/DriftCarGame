using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarShopSelectButton : MonoBehaviour
{
    private Button _selectButton;
    private void Awake()
    {
        _selectButton = GetComponent<Button>();
        if(_selectButton  == null)
        {
            return;
        }
        EventManager<EventTypes.CarShopEvents , Car>.RegisterEvent(EventTypes.CarShopEvents.CarInShopChanged , OnCarInShopChanged);
        
        EventManager<EventTypes.CarShopEvents , Car>.RegisterEvent(EventTypes.CarShopEvents.CarUnlocked , OnCarUnlocked);
    }
    private void OnCarInShopChanged(Car _car)
    {
        if(CarPurchased(_car))
        {
            _selectButton.interactable = true;
            _selectButton.onClick.RemoveAllListeners();
            _selectButton.onClick.AddListener(()=>
            {
                EventManager<EventTypes.CarShopEvents , Car>.TriggerEvent(EventTypes.CarShopEvents.CarSelected, _car);
                _selectButton.interactable = false;
            });
        }
        else
        {
            _selectButton.interactable = false;
        }
    }
    private void OnCarUnlocked(Car _unlockedCar)
    {
        _selectButton.interactable = true;
    }
    private bool CarPurchased(Car _car)
    {
        PlayerGameData _playerData = SaveManager.Load();
        if(_playerData._unlockedCars.Contains(_car._carModel))
        {
            return true;
        }
        else{
            return false;
        }
    }
    
    private void OnDestroy()
    {
        EventManager<EventTypes.CarShopEvents , Car>.UnregisterEvent(EventTypes.CarShopEvents.CarInShopChanged , OnCarInShopChanged);
    }
}
