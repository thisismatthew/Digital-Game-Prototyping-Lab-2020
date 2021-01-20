using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    private GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void MoveAbility()
    {   
        if (GameObject.Find("Move").GetComponent<Image>().color == Color.red)
        {
            gm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            gm.ResetAllNodes();
            GameObject.Find("Move").GetComponent<Image>().color = Color.white;
        }
        else
        {
            gm.currentCharacter.GetComponent<Abilities>().CurrentAbility = gm.currentCharacter.GetComponent<Movement>();
            gm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            GameObject.Find("Move").GetComponent<Image>().color = Color.red;
        }
    }

    public void ShankAbility()
    {
        if (GameObject.Find("StandardShank").GetComponent<Image>().color == Color.red)
        {
            //gm.currentCharacter.GetComponent<Abilities>().selectAbility();
            gm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            gm.ResetAllNodes();
            GameObject.Find("StandardShank").GetComponent<Image>().color = Color.white;
        }
        else
        {
            //gm.currentCharacter.GetComponent<Abilities>().selectAbility(gm.currentCharacter.GetComponent<StandardShank>());
            gm.currentCharacter.GetComponent<Abilities>().CurrentAbility = gm.currentCharacter.GetComponent<StandardShank>();
            gm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            GameObject.Find("StandardShank").GetComponent<Image>().color = Color.red;
        }
    }

    public void BottleRocketAbility()
    {
        if (GameObject.Find("Bottle Rocket").GetComponent<Image>().color == Color.red)
        {
            //gm.currentCharacter.GetComponent<Abilities>().selectAbility();
            gm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            gm.ResetAllNodes();
            GameObject.Find("Bottle Rocket").GetComponent<Image>().color = Color.white;
        }
        else
        {
            //gm.currentCharacter.GetComponent<Abilities>().selectAbility(gm.currentCharacter.GetComponent<BottleRocket>());
            gm.currentCharacter.GetComponent<Abilities>().CurrentAbility = gm.currentCharacter.GetComponent<BottleRocket>();
            gm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            GameObject.Find("Bottle Rocket").GetComponent<Image>().color = Color.red;
        }
    }
}
