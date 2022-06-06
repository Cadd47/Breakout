using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LvlOne()
    {
        SceneManager.LoadScene("1");
    }
}
