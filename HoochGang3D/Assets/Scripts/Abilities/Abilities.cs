using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public Dictionary<string, Ability> abilities;
    private Ability currentAbility;

    public void SetCurrentAbility(string key)
    {
        currentAbility = abilities[key];
    }
}
