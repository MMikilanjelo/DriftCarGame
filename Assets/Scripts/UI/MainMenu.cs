using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    [SerializeField] Object _lvlSelectionMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(_lvlSelectionMenu.name);
    }
}
