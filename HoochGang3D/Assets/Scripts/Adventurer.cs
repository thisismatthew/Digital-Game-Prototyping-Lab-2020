using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Adventurer : Character
{
    public GameObject agentUI;
    public AdventurerAI ai;
    public CameraController cc;

    protected override void Start()
    {
        cc = GameObject.Find("Camera").GetComponent<CameraController>();
        ai = gameObject.GetComponent<AdventurerAI>();
        agentUI = transform.Find("AgentUI").gameObject;
        base.Start();
    }

    private void Update()
    {
        if (tm.currentCharacter == this.gameObject)
        {
            agentUI.SetActive(true);
            return;
        }

        agentUI.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on an Adventurer");
        //check if game is over
        if (tm.gameObject.GetComponent<GameManager>().gameIsOver)
        {
            return;
        }
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/
        if (tm.currentCharacter.CompareTag(this.tag))
        {
            return; //don't interact during Adventurer turns
        }
        if (tm.currentCharacter.GetComponent<Abilities>().CurrentAbility == null)
        {
            return;
        }
        if (!tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.isAttack)
        {
            return; //don't interact if current ability isn't an attack
        }
        if (!CCInRange())
        {
            Debug.Log("Failed here!");
            return;
        }

        Debug.Log("Passed All Checks!");

        tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Execute(this.gameObject);
        if (tm.currentCharacter.GetComponent<Goblin>().ActionsLeft == 0)
        {
            tm.currentCharacter.GetComponent<Goblin>().TurnTaken = true;
            //cycle the character in the turn manager. 
            StartCoroutine(tm.NextCharacter());
        }
    }

    private bool CCInRange()
    {
        float dist = Vector3.Distance(currentNode.transform.position, tm.currentCharacter.GetComponent<Character>().CurrentNode.transform.position);
        if (dist <= tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Range*5.5f)
        {
            return true;
        }

        return false;
    }

    // this is called by the turn manager and uses the ai script to take actions
    public void TakeTurn()
    {
        cc.CentreCameraOnTransform(transform.position);
        ai.Action(this); //NextCharacter moved into AdventurerAI script
    }
}
