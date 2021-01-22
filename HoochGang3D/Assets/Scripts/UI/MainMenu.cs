using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //presumably we'll move on from Prototype_Environment_X
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
