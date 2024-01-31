using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CarDisplay : MonoBehaviour
{
    [SerializeField] private Transform _carHolder;
    [SerializeField] private Text _carName;
    [SerializeField] private Text _carDescription;

    [SerializeField] private Image _carSpeed;
    public void DisplayCar(Car _carToDisplay)
    {
        _carName.text = _carToDisplay._carName;
        _carDescription.text  = _carToDisplay._carDescription;
        _carSpeed.fillAmount = _carToDisplay._carStats._carSpeed / 10000;
        if(_carHolder.childCount > 0)
        {
            Destroy(_carHolder.GetChild(0).gameObject);
        }
        var _carInstance = Instantiate(_carToDisplay._carModel , _carHolder.position , _carHolder.rotation , _carHolder);
        _carInstance.transform.localScale = new Vector3(30,30,30);
    }
}
