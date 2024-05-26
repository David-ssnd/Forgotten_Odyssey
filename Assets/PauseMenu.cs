using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private AudioSource backgroundMusic;

    public void Pause()
    {
        if (backgroundMusic == null)
        {
            // Get the background music if it is still null
            backgroundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>();

            // If it's still null, log a message
            if (backgroundMusic == null)
            {
                Debug.Log("Background music not found");
                return;
            }
        }
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        backgroundMusic.Pause();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
