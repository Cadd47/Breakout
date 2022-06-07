using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseUI;

    private void Awake()
    {
        Screen.SetResolution(1920, 1200, true);
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void MainMenu()
    {
        Application.Quit();
    }

    public void LvlOne()
    {
        SceneManager.LoadScene("1");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
