using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuUI;
    public GameObject gameUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame ()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        paused = false;
        AudioListener.pause = false;
    }

    public void PauseGame ()
    {
        pauseMenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        paused = true;
        AudioListener.pause = true;
    }

    public void LoadGunShop()
    {
        Debug.Log("Loading gun");
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }
}
