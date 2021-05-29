using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManfager : MonoBehaviour
{
    string soloScene = "MultScene"; 
    string multScene = "Level1"  ;
    string MainMenu = "MainMenu";
    public void PlaySolo()
    {
        SceneManager.LoadScene(soloScene);
    }
    public void PlayMult()
    {
        SceneManager.LoadScene(multScene);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
