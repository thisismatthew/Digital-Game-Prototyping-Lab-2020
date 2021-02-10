using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public GameObject brewery;
    [HideInInspector] public bool gameIsOver;

    [Header("Nodes")]

    public GameObject[][] worldGraph;
    public GameObject endUI;

    private void Start()
    {
        Time.timeScale = 1;
        gameIsOver = false;

        brewery = GameObject.FindGameObjectWithTag("Well");
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
        endUI.SetActive(true); //to start with, have a single screen to show the game has ended

        if (result == "Victory")
        {
            //show victory UI
            endUI.GetComponentInChildren<Text>().text = "VICTORY";
            Debug.Log("You Win!");
        }
        else
        {
            //show defeat UI
            endUI.GetComponentInChildren<Text>().text = "DEFEAT";
            Debug.Log("You Lose!");
        }

        Time.timeScale = 0;
    }
}

