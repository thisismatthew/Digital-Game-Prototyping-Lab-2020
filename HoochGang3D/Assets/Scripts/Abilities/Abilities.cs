using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public Ability[] abilities;
    private Ability currentAbility;
    public GameObject agentUI;

    public void SetCurrentAbility(int index)
    {
        if (index > abilities.Length)
        {
            currentAbility = null;
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

    public void HideUI()
    {
        agentUI.SetActive(false);
    }

    public void ShowUI()
    {
        agentUI.SetActive(true);
    }
}
