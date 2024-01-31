using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyController : MonoBehaviour
{
    private int _currentCurrency => SaveManager._saveMangerInstance._currency;
    [SerializeField] Text _currencyText;
    void Start()
    {
        _currencyText.text = _currentCurrency.ToString();
    } 
}
