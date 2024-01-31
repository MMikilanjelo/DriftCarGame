using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    private const string _mainGameSceneName ="GameCortScene";
    public void StartGame()
    {
        SceneManager.LoadScene(_mainGameSceneName);
    }
}
