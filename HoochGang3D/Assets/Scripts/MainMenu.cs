using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //presumably we'll move on from Prototype_Environment_2
    }

    public void ShowCredits()
    {
        //load some kind of panel showing our names and roles
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
