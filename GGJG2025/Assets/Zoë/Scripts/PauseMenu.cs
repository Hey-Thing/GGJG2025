using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    private void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        { if (isPaused)
            { OnResumePress(); }
            else
            { PauseGame(); }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void OnResumePress()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OnQuitPress()
    {
        Application.Quit();
    }

    public void OnMainMenuPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
