using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    
    // Script qui gere l'interface du game over

    public GameObject GameOverUI; // on recupere l'interface UI du gameover

    public static GameOver instance; 
 
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    public void OnPlayerDeath() // quand le player meurt on active l'interface de GO
    {
        GameOverUI.SetActive(true);
    }

    public void ButtonRetry() // appelé quand on appuie sur le bouton retry 
    {
        SceneManager.LoadScene("SampleScene"); // sample scene == scene du niveau
    }

    public void ButtonMainMenu() 
    {
        SceneManager.LoadScene("Launcher");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
