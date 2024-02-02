using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Net.NetworkInformation;
using TMPro;
public class CarDisplay : MonoBehaviour
{
    [Header("Pivot for placing cars in scene")]
    [SerializeField] private Transform _carHolder;
    
    [Header("Car info")]
    [SerializeField] private Text _carNameText;
    [SerializeField] private Text _carDescriptionText;
    [SerializeField] private Image _carSpeedImage;
    [SerializeField] private Text _carPriceText;
    
    [Header("Buy Car button")]
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectCarButton;

    public void DisplayCar(Car _carToDisplay)
    {
        if(_carToDisplay == null) return;

        DisplayCarStats(_carToDisplay);
        
        InstantiateCarModel(_carToDisplay);
        
        EventManager<EventTypes.CarShopEvents , Car>.TriggerEvent(EventTypes.CarShopEvents.CarInShopChanged , _carToDisplay);
    }
    private void DisplayCarStats(Car _carToDisplay)
    {

        _carNameText.text = _carToDisplay._carName;
        _carDescriptionText.text  = _carToDisplay._carDescription;
        _carSpeedImage.fillAmount = _carToDisplay._carStats._motorPower / 1000;

    }
    private void InstantiateCarModel(Car _carToDisplay)
    {
        if(_carHolder.childCount > 0)
        {
            Destroy(_carHolder.GetChild(0).gameObject);
        }
        Instantiate(_carToDisplay._carGameObject , _carHolder.position , _carHolder.rotation , _carHolder);
    }
}
