using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        EnableUIOnCharacter();
        nodes = GameObject.FindGameObjectsWithTag("Node");
    }

    private void Update()
    {
        if (currentCharacter == null || !currentCharacter.gameObject.activeSelf)
        {
            NextCharacter();
        }

        if (currentCharacter.GetComponent<Abilities>().CurrentAbility != null)
        {
            foreach (GameObject n in nodes)
            {
                n.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    public void NextCharacter()
    {
        ResetAllNodes();
        currentCharacter.GetComponent<Abilities>().SetCurrentAbility(999);

        if (System.Array.IndexOf(characters, currentCharacter) + 1 == characters.Length)
        {
            foreach (GameObject c in characters)
            {
                if (c != null)
                {
                    currentCharacter = c;
                    EnableUIOnCharacter();
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
                    EnableUIOnCharacter();
                    return;
                }
            }
        }
    }

    public void ResetAllNodes()
    {
        foreach (GameObject n in nodes)
        {
            n.GetComponent<Node>().ResetNode();
            n.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void EnableUIOnCharacter()
    {
        foreach(GameObject g in characters)
        {
            if(g != currentCharacter)
            {
                g.GetComponent<Abilities>().HideUI();
            }
            else
            {
                g.GetComponent<Abilities>().ShowUI();
            }
        }
    }
}