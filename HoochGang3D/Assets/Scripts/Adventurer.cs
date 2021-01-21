using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Adventurer : Character
{
    public GameObject agentUI;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (gm.currentCharacter == this.gameObject)
        {
            agentUI.SetActive(true);
            return;
        }

        agentUI.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (gm.currentCharacter.CompareTag(this.tag))
        {
            return; //don't interact during Adventurer turns
        }
        if (gm.currentCharacter.GetComponent<Abilities>().CurrentAbility == null)
        {
            return;
        }
        if (!gm.currentCharacter.GetComponent<Abilities>().CurrentAbility.isAttack)
        {
            return; //don't interact if current ability isn't an attack
        }
        if (!CCInRange())
        {
            return;
        }

        gm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Execute(this.gameObject);
    }

    private bool CCInRange()
    {
        float dist = Vector3.Distance(currentNode.transform.position, gm.currentCharacter.GetComponent<Character>().CurrentNode.transform.position);
        if (dist <= gm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Range*5)
        {
            return true;
        }

        return false;
    }
}
