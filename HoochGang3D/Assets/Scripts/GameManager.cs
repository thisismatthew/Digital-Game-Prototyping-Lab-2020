using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Characters")]
    public GameObject[] characters;
    public GameObject currentCharacter;

    [Header("Nodes")]
    public GameObject[] nodes;

    private void Start()
    {
        currentCharacter = characters[0];
        nodes = GameObject.FindGameObjectsWithTag("Node");
    }

    public void NextCharacter()
    {
        if (System.Array.IndexOf(characters, currentCharacter) + 1 == characters.Length)
        {
<<<<<<< HEAD
            currentCharacter = characters[0];
=======
            currentCharacter = characters[0]; //reset to start
>>>>>>> main
            return;
        }

        currentCharacter = characters[System.Array.IndexOf(characters, currentCharacter) + 1];
        return;
    }
}
