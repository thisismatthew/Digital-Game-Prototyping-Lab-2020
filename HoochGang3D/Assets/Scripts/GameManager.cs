using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Characters")]
    public GameObject[] characters;
    public GameObject currentCharacter;

    [Header("Nodes")]
    public GameObject[] nodes;

    private void Start()
    {
        currentCharacter = characters[0];
        nodes = GameObject.FindGameObjectsWithTag("Node");
    }

    private void Update()
    {
        if (currentCharacter == null)
        {
            NextCharacter();
        }
    }

    public void NextCharacter()
    {
        ResetAllNodes();

        if (System.Array.IndexOf(characters, currentCharacter) + 1 == characters.Length)
        {
            foreach (GameObject c in characters)
            {
                if (c != null)
                {
                    currentCharacter = c;
                    return;
                }
            }
        }
        else
        {
            for (int i = System.Array.IndexOf(characters, currentCharacter) + 1; i < characters.Length; i++)
            {
                if (characters[i] != null)
                {
                    currentCharacter = characters[i];
                    return;
                }
            }
        }

        currentCharacter.GetComponent<Abilities>().SetCurrentAbility(999);
    }

    public void ResetAllNodes()
    {
        foreach (GameObject n in nodes)
        {
            n.GetComponent<Node>().ResetNode();
        }
    }
}