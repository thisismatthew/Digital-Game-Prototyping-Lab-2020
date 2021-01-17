using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public Ability[] abilities;
    private Ability currentAbility;
    public GameObject agentUI;
    public GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
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

    public Ability CurrentAbility
    {
        get
        {
            return currentAbility;
        }
    }

    //The methods below really should go in their own script but for now they are here

    public void HideUI()
    {
        //Debug.Log("Disabled UI");
        agentUI.SetActive(false);
    }

    public void ShowUI()
    {
        //Debug.Log("Enabled UI");
        agentUI.SetActive(true);
    }
    private void OnMouseDown()
    {
        gm.SelectCharacter(this.gameObject);
    }
}
