using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;

namespace Com.Epicure.Kairos
{
    public class PauseMenu : MonoBehaviourPunCallbacks
    {
        public static bool gameIsPaused = false;
        public GameObject PausedMenu;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (gameIsPaused)  // si la game est en pause on quite et on reprend le cours de la partie
                {
                    Resume();
                }
                else
                {
                    Paused();
                }
            }
        }

        void Paused()
        {
            PausedMenu.SetActive(true);
            Time.timeScale = 0; // met le temps a 0
            gameIsPaused = true;
        }

        public void Resume()
        {
            PausedMenu.SetActive(false);
            Time.timeScale = 1; // on remet le temps a 1 
            gameIsPaused = false;
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("Launcher");
            Resume();
        }

    }

}