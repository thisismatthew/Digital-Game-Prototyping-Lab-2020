using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public Ability[] abilities;
    private Ability currentAbility;
    //private GameManager gm;

    private void Start()
    {
        //gm = FindObjectOfType<GameManager>();
    }

    /*public void SetCurrentAbility(int index)
    {
        if (index > abilities.Length)
        {
            currentAbility = null;
            return;
        }

        currentAbility = abilities[index];
    }*/

    /*public void selectAbility(Ability abilityToSet)
    {
        //check if ability exists in the abilities list
        foreach(Ability a in abilities)
        {
            if(a == abilityToSet)
            {
                //set it
                currentAbility = a;
                return;
            }
        }

        currentAbility = null;
    }*/

    /*private void Update()
    {
        currentAbility.DisplayRange();
    }*/

    public Ability CurrentAbility
    {
        set
        {
            foreach (Ability a in abilities)
            {
                if (a == value)
                {
                    //set it
                    currentAbility = a;
                    return;
                }
            }

            currentAbility = value;
        }
        get
        {
            return currentAbility;
        }
    }
}
