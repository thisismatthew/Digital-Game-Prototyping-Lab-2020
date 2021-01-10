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
        SelectCharacter(characters[0]);
        nodes = GameObject.FindGameObjectsWithTag("Node");
    }

    public void NextCharacter()
    {
        if (System.Array.IndexOf(characters, currentCharacter) + 1 == characters.Length)
        {
            SelectCharacter(characters[0]); //reset to start
            return;
        }

        SelectCharacter(characters[System.Array.IndexOf(characters, currentCharacter) + 1]);
        return;
    }

    public void SelectCharacter(GameObject characterToSelect)
    {
        currentCharacter = characterToSelect;
        currentCharacter.GetComponent<Movement>().selected = true;
        foreach(GameObject c in characters)
        {
            if(c != currentCharacter)
            {
                c.GetComponent<Movement>().selected = false;
            }
        }
    }
}
