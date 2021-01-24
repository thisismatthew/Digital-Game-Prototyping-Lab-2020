using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public GameObject brewery;
    private bool gameIsOver;

    private void Start()
    {
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver) //if game has ended, do not continue;
        {
            return;
        }

        if (!GetComponent<TurnManager>().CharactersAlive("a")) //if all adventurers dead
        {
            Victory();
            return;
        }

        if (!GetComponent<TurnManager>().CharactersAlive("g") || brewery == null) //if all goblins dead or brewery destroyed
        {
            Defeat();
            return;
        }
    }

    private void Victory()
    {
        //player wins
        gameIsOver = true;
        Time.timeScale = 0; //stop the game
    }
    
    private void Defeat()
    {
        //player loses
        gameIsOver = true;
        Time.timeScale = 0;
    }
}
