using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [Header("Characters")]
    public GameObject[] characters; //handles turn order
    //cutting back on tag comparisons
    [HideInInspector]public List<GameObject> goblins;
    [HideInInspector]public List<GameObject> adventurers;
    public GameObject currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        goblins = new List<GameObject>();
        adventurers = new List<GameObject>();

        foreach (GameObject c in characters)
        {
            if (c.CompareTag("Goblin"))
            {
                goblins.Add(c);
            }
            else
            {
                adventurers.Add(c);
            }
        }

        currentCharacter = characters[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCharacter == null || !currentCharacter.gameObject.activeSelf || currentCharacter.CompareTag("Adventurer")) //last condition is just to skip enemy turn until Enemy AI is implemented
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

    public bool CharactersAlive(string tag)
    {
        if (tag == "g")
        {
            foreach (GameObject g in goblins)
            {
                if (g != null) //if a goblin is alive
                {
                    return true;
                }
            }
        }
        else
        {
            foreach (GameObject a in adventurers)
            {
                if (a != null) //if an adventurer is alive
                {
                    return true;
                }
            }
        }

        return false;
    }
}
