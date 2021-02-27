using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour // script qui gere le menu du jeu 
{
    public string levelToLoad; 

    public GameObject SettingWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        SettingWindow.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void closeSettings()
    {
        SettingWindow.SetActive(false);
    }
}
