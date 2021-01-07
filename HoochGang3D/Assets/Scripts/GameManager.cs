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

    [Header("Materials")]
    [SerializeField] private Material inRangeMaterial;
    [SerializeField] private Material startMaterial;

    private void Start()
    {
        currentCharacter = characters[0];
        nodes = GameObject.FindGameObjectsWithTag("Node");
    }

    private void Update()
    {
        foreach (GameObject n in nodes)
        {
            if (n != currentCharacter.GetComponent<Movement>().currentNode && currentCharacter.GetComponent<Movement>().currentNode != null)
            {
                if (Vector3.Distance(currentCharacter.GetComponent<Movement>().currentNode.transform.position, n.transform.position) <= currentCharacter.GetComponent<Movement>().range * 5)
                {
                    n.GetComponent<Node>().SetRenderer(inRangeMaterial);
                }
            }
        }
    }

    public void NextCharacter()
    {
        ResetNodes();

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

    public void ResetNodes()
    {
        foreach (GameObject n in nodes)
        {
            n.GetComponent<Node>().SetRenderer(startMaterial);
        }
    }
}
