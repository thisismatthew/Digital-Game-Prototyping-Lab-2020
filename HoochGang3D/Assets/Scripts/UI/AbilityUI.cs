using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    private TurnManager tm;
    private NodeManager nm;

    private void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
        nm = GameObject.Find("GameManager").GetComponent<NodeManager>();
    }

    public void MoveAbility()
    {   
        if (GameObject.Find("Move").GetComponent<Image>().color == Color.red)
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            nm.ResetAllNodes();
            GameObject.Find("Move").GetComponent<Image>().color = Color.white;
        }
        else
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = tm.currentCharacter.GetComponent<Movement>();
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            GameObject.Find("Move").GetComponent<Image>().color = Color.red;
        }
    }

    public void ShankAbility()
    {
        if (GameObject.Find("StandardShank").GetComponent<Image>().color == Color.red)
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            nm.ResetAllNodes();
            GameObject.Find("StandardShank").GetComponent<Image>().color = Color.white;
        }
        else
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = tm.currentCharacter.GetComponent<StandardShank>();
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            GameObject.Find("StandardShank").GetComponent<Image>().color = Color.red;
        }
    }

    public void BottleRocketAbility()
    {
        if (GameObject.Find("Bottle Rocket").GetComponent<Image>().color == Color.red)
        {
            //gm.currentCharacter.GetComponent<Abilities>().selectAbility();
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            nm.ResetAllNodes();
            GameObject.Find("Bottle Rocket").GetComponent<Image>().color = Color.white;
        }
        else
        {
            //gm.currentCharacter.GetComponent<Abilities>().selectAbility(gm.currentCharacter.GetComponent<BottleRocket>());
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = tm.currentCharacter.GetComponent<BottleRocket>();
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            GameObject.Find("Bottle Rocket").GetComponent<Image>().color = Color.red;
        }
    }
}
