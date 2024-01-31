using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlDisplay : MonoBehaviour
{
    [SerializeField] private Text _lvlName;
    [SerializeField] private Text _lvlDescription;
    [SerializeField] private Image _lvlImage;
    [SerializeField] private Button _playButton;
    public void DisplayLvl(Level _levelToDisplay)
    {
        _lvlName.text = _levelToDisplay?._lvlName;
        _lvlDescription.text = _levelToDisplay?._lvlDescription;
        _lvlImage.sprite = _levelToDisplay?._lvlImage;
        _playButton.onClick.RemoveAllListeners();
        _playButton.onClick.AddListener(()=>
        {
            SceneManager.LoadScene(_levelToDisplay._lvlScene.name);
        });
    }
}
