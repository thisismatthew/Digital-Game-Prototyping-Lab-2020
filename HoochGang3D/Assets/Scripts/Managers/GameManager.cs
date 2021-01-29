using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public GameObject brewery;
    [HideInInspector] public bool gameIsOver;

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
            EndGame("Victory");
            return;
        }

        if (!GetComponent<TurnManager>().CharactersAlive("g") || brewery == null) //if all goblins dead or brewery destroyed
        {
            EndGame("Defeat");
            return;
        }
    }

    private void EndGame(string result)
    {
        gameIsOver = true;

        if (result == "Victory")
        {
            //show victory UI
            Debug.Log("You Win!");
        }
        else
        {
            //show defeat UI
            Debug.Log("You Lose!");
        }

        Time.timeScale = 0;
    }
}
