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

    public void SetCurrentAbility(int index)
    {
        if (index > abilities.Length)
        {
            currentAbility = null;
            return;
        }

        currentAbility = abilities[index];
    }

    public void selectAbility(Ability abilityToSet = null)
    {
        //check if ability exists in the abilities list
        foreach(Ability a in abilities)
        {
            if(a == abilityToSet)
            {
                //set it
                currentAbility = abilityToSet;
            }
        }
    }

    public Ability CurrentAbility
    {
        get
        {
            return currentAbility;
        }
    }
}
