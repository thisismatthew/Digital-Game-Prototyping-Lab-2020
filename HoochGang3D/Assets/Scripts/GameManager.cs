using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject currentCharacter;
    [HideInInspector] public int i;

    private void Start()
    {
        currentCharacter = characters[0];
        i = 0;
    }

    public void NextCharacter()
    {
        if (System.Array.IndexOf(characters, currentCharacter) + 1 == characters.Length)
        {
            currentCharacter = characters[0];
            return;
        }

        currentCharacter = characters[System.Array.IndexOf(characters, currentCharacter) + 1];
        return;
    }
}
