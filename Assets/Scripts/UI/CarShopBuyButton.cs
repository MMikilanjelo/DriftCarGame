using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.UI;

public class CarShopBuyButton : MonoBehaviour
{
    private Button _buyButton;
    public void Awake()
    {
        
        _buyButton = GetComponent<Button>();
        if(_buyButton == null)
        {
            return;
        }
        EventManager<EventTypes.CarShopEvents , Car>.RegisterEvent(EventTypes.CarShopEvents.CarInShopChanged , OnCarInShopChanged);
    }
    private void OnCarInShopChanged(Car _car)
    {
        if(CarPurchased(_car))
        {
            _buyButton.interactable = false;
        }
        else
        {
            _buyButton.interactable = true;
            _buyButton.onClick.RemoveAllListeners();
            _buyButton.onClick.AddListener(()=>  
            {
                EventManager<EventTypes.CarShopEvents , Car>.TriggerEvent(EventTypes.CarShopEvents.CarUnlocked , _car);
                _buyButton.interactable = false;
            });
        }

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
