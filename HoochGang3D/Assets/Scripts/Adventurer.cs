using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Adventurer : Character
{
    public GameObject agentUI;
    public AdventurerAI ai;


    protected override void Start()
    {
        ai = gameObject.GetComponent<AdventurerAI>();
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
        //check if game is over
        if (tm.gameObject.GetComponent<GameManager>().gameIsOver)
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
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
            return;
        }

        tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Execute(this.gameObject);
    }

    private bool CCInRange()
    {
        float dist = Vector3.Distance(currentNode.transform.position, tm.currentCharacter.GetComponent<Character>().CurrentNode.transform.position);
        if (dist <= tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Range*5)
        {
            return true;
        }

        return false;
    }

    // this is called by the turn manager and uses the ai script to take actions
    public void TakeTurn()
    {
        ai.Action(this);
        StartCoroutine(tm.NextCharacter());
    }
}
