using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [Header("Characters")]
    //changed characters from an array to a list for easy adding and deleting
    public List<GameObject> characters; //handles turn order
    //cutting back on tag comparisons
    [HideInInspector]public List<GameObject> goblins;
    [HideInInspector]public List<GameObject> adventurers;
    public AdventurerAI ai;
    private bool playersTurn = true; 
    public GameObject currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        ai = new AdventurerAI();
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
        //reseting the nodes just returns them to thier original material color
        GetComponent<NodeManager>().ResetAllNodes();
        //current ability is set to null on the character that just executed an ability. 
        currentCharacter.GetComponent<Abilities>().CurrentAbility = null;

        //if there is a null character in the master list, remove it. 
        foreach (GameObject c in characters)
        {
            if (c == null)
            {
                characters.Remove(c);
            }
        }

        //check if its the players turn
        if (playersTurn)
        {
            currentCharacter.GetComponent<Goblin>().TurnTaken = true;
            //loop through to the next goblin that has to take a turn. 
            foreach(GameObject goblin in goblins)
            {
                if (!goblin.GetComponent<Goblin>().TurnTaken)
                {
                    currentCharacter = goblin;
                    break;
                }
            }
            if (currentCharacter.GetComponent<Goblin>().TurnTaken)
            {
                //reset the goblins and set it to the AI's turns. 
                Debug.Log("goblins turns are over");
                foreach (GameObject goblin in goblins)
                    goblin.GetComponent<Goblin>().TurnTaken = false;
                currentCharacter = adventurers[0];
                playersTurn = false;

                //also call the first move from the AI
                ai.TakeTurn();
            }
            
        }

        if (!playersTurn)
        {
            currentCharacter.GetComponent<Adventurer>().TurnTaken = true;
            //loop through to the next adventurer that has to take a turn. 
            foreach (GameObject adventurer in adventurers)
            {
                if (!adventurer.GetComponent<Goblin>().TurnTaken)
                {
                    currentCharacter = adventurer;
                    ai.TakeTurn();
                    break;
                }
            }
            if (currentCharacter.GetComponent<Adventurer>().TurnTaken)
            {
                //reset the adventurers and set it to the player's turns. 
                Debug.Log("adventurers turns are over");
                foreach (GameObject adventurer in adventurers)
                    adventurer.GetComponent<Adventurer>().TurnTaken = false;
                currentCharacter = goblins[0];
                playersTurn = true;
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
