using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [Header("Characters")]
    //changed characters from an array to a list for easy adding and deleting
    //public List<GameObject> characters; //handles turn order
    //cutting back on tag comparisons
    public List<GameObject> goblins;
    public List<GameObject> adventurers;
    private bool playersTurn = true; 
    public GameObject currentCharacter;
    public Text turnIndicator;
    public Text actionsIndicator;
    public CameraController cameraController;
    public float secondsBetweenTurns = 1;
    public WaveManager wm;

    // Start is called before the first frame update
    void Start()
    {
        //cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
        goblins = new List<GameObject>();
        adventurers = new List<GameObject>();

        goblins.AddRange(GameObject.FindGameObjectsWithTag("Goblin")); //get all gameObjects with Goblin tag
        adventurers.AddRange(GameObject.FindGameObjectsWithTag("Adventurer")); //repeat with adventurer tag

        currentCharacter = goblins[0]; //player goes first to set up

        cameraController.CentreCameraOnTransform(currentCharacter.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //if game is over, don't execute
        if (GetComponent<GameManager>().gameIsOver)
        {
            return;
        }

        //if there is a null character in the master list, remove it.
        foreach (GameObject g in goblins)
        {
            //this kind of for loop can sometimes generate errors when the collection is modified externally, 
            //if it annoys you, switch to a normal for loop instead of a for each loop
            if (g == null)
            {
                goblins.Remove(g);
            }
        }
        
        foreach (GameObject a in adventurers)
        {
            if (a == null)
            {
                adventurers.Remove(a);
            }
        }

        if (currentCharacter == null || !currentCharacter.gameObject.activeSelf) //last condition is just to skip enemy turn until Enemy AI is implemented
        {
            StartCoroutine(NextCharacter());
        }

        if (currentCharacter != null && currentCharacter.GetComponent<Abilities>().CurrentAbility != null)
        {
            foreach (GameObject n in GetComponent<NodeManager>().nodes)
            {
                //n.transform.GetChild(0).gameObject.SetActive(false);
                n.transform.Find("Detector").gameObject.SetActive(false);
            }
        }

        if(playersTurn && turnIndicator.text != "Your Turn") //only change the text if it's not what we want it to be and if it's the player's turn
        {
            turnIndicator.text = "Your Turn";
        }
        else if(turnIndicator.text != "Enemies' Turn" && !playersTurn) //Don't set the text to enemies turn every frame unless it's different
        {
            turnIndicator.text = "Enemies' Turn";
        }

        actionsIndicator.text = currentCharacter.GetComponent<Character>().ActionsLeft.ToString();
    }

    public IEnumerator NextCharacter()
    {
        //wait one second on begining this coroutine
        yield return new WaitForSeconds(secondsBetweenTurns);

        //reseting the nodes just returns them to thier original material color
        GetComponent<NodeManager>().ResetAllNodes();
        //current ability is set to null on the character that just executed an ability. 
        if(currentCharacter != null)
        {
            currentCharacter.GetComponent<Abilities>().CurrentAbility = null; 
        }

        //check if its the players turn
        if (playersTurn)
        {
            //loop through to the next goblin that has to take a turn. 
            foreach(GameObject goblin in goblins)
            {
                if (!goblin.GetComponent<Goblin>().TurnTaken)
                {
                    //play new goblin turn bottle sound
                    FindObjectOfType<AudioManager>().Play("Goblins_Turn_Bottle");
                    currentCharacter = goblin;
                    break;
                }
            }
            if (currentCharacter.GetComponent<Goblin>().TurnTaken)
            {
                //reset the goblins and set it to the AI's turns. 
                Debug.Log("goblins turns are over");
                foreach (GameObject goblin in goblins) {
                    goblin.GetComponent<Goblin>().TurnTaken = false;
                    goblin.GetComponent<Goblin>().ActionsLeft = 2;
                }
                
                FindObjectOfType<AudioManager>().Play("Adventurer_Turns_March");
                currentCharacter = adventurers[0];
                playersTurn = false;

                //also call the first move from the AI
                currentCharacter.GetComponent<Adventurer>().TakeTurn();
            }
            cameraController.CentreCameraOnTransform(currentCharacter.transform.position);
        }

        if (!playersTurn)
        {
            currentCharacter.GetComponent<Adventurer>().TurnTaken = true;
            //loop through to the next adventurer that has to take a turn. 
            foreach (GameObject adventurer in adventurers)
            {
                if (!adventurer.GetComponent<Adventurer>().TurnTaken)
                {
                    currentCharacter = adventurer;
                    currentCharacter.GetComponent<Adventurer>().TakeTurn();

                    break;
                }
            }
            if (currentCharacter.GetComponent<Character>().TurnTaken)
            {
                //reset the adventurers and set it to the player's turns. 
                Debug.Log("adventurers turns are over");
                foreach (GameObject adventurer in adventurers)
                    adventurer.GetComponent<Adventurer>().TurnTaken = false;
                currentCharacter = goblins[0];
                playersTurn = true;
                //TODO adventurer turns happen so quickly that the audio gets stopped before it starts. 
                //FindObjectOfType<AudioManager>().Stop("Adventurer_Turns_March");
            }
            //cameraController.timer = 5f;
            cameraController.UnFocus();
        }

        //cameraController.CentreCameraOnTransform(currentCharacter.transform.position);
    }

    public bool CharactersAlive(string tag)
    {
        if (tag == "g")
        {
            if (goblins.Count > 0)
            {
                return true;
            }
        }
        else
        {
            if (adventurers.Count > 0)
            {
                return true;
            }
        }

        return false;
    }
}
