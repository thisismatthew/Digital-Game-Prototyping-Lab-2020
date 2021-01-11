using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public Ability[] abilities;
    private Ability currentAbility;

    public void SetCurrentAbility(int index)
    {
        if (index > abilities.Length)
        {
            return;
        }

        currentAbility = abilities[index];
    }

    public Ability CurrentAbility
    {
        get
        {
            return currentAbility;
        }
    }
}
