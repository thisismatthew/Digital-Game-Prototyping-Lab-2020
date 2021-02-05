using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    private TurnManager tm;
    private NodeManager nm;
    public Button[] buttons;

    private void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
        nm = GameObject.Find("GameManager").GetComponent<NodeManager>();
    }

    private Abilities GetCurrentAbilities()
    {
        return tm.currentCharacter.GetComponent<Abilities>();
    }

    private void HighlightButton(GameObject pressedButton)
    {
        foreach(Button b in buttons) //reset the visuals of all the other buttons
        {
            ResetButton(b.gameObject);
        }

        pressedButton.GetComponent<Image>().color = Color.red; //provide a visual indicator that shows the button has been pressed
    }

    private void ResetButton(GameObject b)
    {
        b.GetComponent<Image>().color = Color.white; //return the button to what it was when we started
    }

    public void MoveAbility()
    {
        if(GetCurrentAbilities().CurrentAbility is GoblinMovement)
        {
            GetCurrentAbilities().CurrentAbility = null;
            nm.ResetAllNodes();
            //GameObject.Find("Move").GetComponent<Image>().color = Color.white;
            ResetButton(GameObject.Find("Move"));
        }
        else
        {
            GetCurrentAbilities().CurrentAbility = tm.currentCharacter.GetComponent<Movement>();
            GetCurrentAbilities().CurrentAbility.DisplayRange();
            //GameObject.Find("Move").GetComponent<Image>().color = Color.red;
            HighlightButton(GameObject.Find("Move"));
        }

        /*if (GameObject.Find("Move").GetComponent<Image>().color == Color.red)
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
        }*/
    }

    public void ShankAbility()
    {
        if(GetCurrentAbilities().CurrentAbility is StandardShank)
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            nm.ResetAllNodes();
            ResetButton(GameObject.Find("StandardShank"));
        }
        else
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = tm.currentCharacter.GetComponent<StandardShank>();
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            HighlightButton(GameObject.Find("StandardShank"));
        }

        /*if (GameObject.Find("StandardShank").GetComponent<Image>().color == Color.red)
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
        }*/
    }

    public void BottleRocketAbility()
    {
        if(GetCurrentAbilities().CurrentAbility is BottleRocket)
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            nm.ResetAllNodes();
            //GameObject.Find("Bottle Rocket").GetComponent<Image>().color = Color.white;
            ResetButton(GameObject.Find("Bottle Rocket"));
        }
        else
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = tm.currentCharacter.GetComponent<BottleRocket>();
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            //GameObject.Find("Bottle Rocket").GetComponent<Image>().color = Color.red;
            HighlightButton(GameObject.Find("Bottle Rocket"));
        }

        /*if (GameObject.Find("Bottle Rocket").GetComponent<Image>().color == Color.red)
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            nm.ResetAllNodes();
            GameObject.Find("Bottle Rocket").GetComponent<Image>().color = Color.white;
        }
        else
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = tm.currentCharacter.GetComponent<BottleRocket>();
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            GameObject.Find("Bottle Rocket").GetComponent<Image>().color = Color.red;
        }*/
    }

    public void Pass()
    {
        if(GetCurrentAbilities().CurrentAbility is Pass)
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
            nm.ResetAllNodes();
            ResetButton(GameObject.Find("Pass"));
        }
        else
        {
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = tm.currentCharacter.GetComponent<Pass>();
            //tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
            //HighlightButton(GameObject.Find("Pass"));
            tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Execute(this.gameObject);
            tm.currentCharacter.GetComponent<Goblin>().TurnTaken = true;
        }
    }
}
