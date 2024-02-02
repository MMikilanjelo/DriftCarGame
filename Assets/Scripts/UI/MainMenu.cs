using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    [SerializeField] Object _lvlSelectionMenuScene;
    [SerializeField] Object _carShopMenuScene;
    [SerializeField] Button _lvlSelectionButton;
    [SerializeField] Button _carShopMenuButton;
    private void Awake()
    {
        _lvlSelectionButton.onClick.AddListener(() => SceneManager.LoadScene(_lvlSelectionMenuScene.name));
        _carShopMenuButton.onClick.AddListener(() =>  SceneManager.LoadScene(_carShopMenuScene.name));
    }

}
