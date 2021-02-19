using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //presumably we'll move on from Prototype_Environment_2
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisplayCredits()
    {
        credits.SetActive(true);
    }
}
