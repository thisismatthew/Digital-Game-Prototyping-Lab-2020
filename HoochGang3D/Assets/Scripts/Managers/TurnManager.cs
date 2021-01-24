using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [Header("Characters")]
    public GameObject[] characters;
    public GameObject currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = characters[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCharacter == null || !currentCharacter.gameObject.activeSelf)
        {
            NextCharacter();
        }

        if (currentCharacter.GetComponent<Abilities>().CurrentAbility != null)
        {
            foreach (GameObject n in GetComponent<NodeManager>().nodes)
            {
                n.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    public void NextCharacter()
    {
        GetComponent<NodeManager>().ResetAllNodes();
        currentCharacter.GetComponent<Abilities>().CurrentAbility = null;

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
    }
}
