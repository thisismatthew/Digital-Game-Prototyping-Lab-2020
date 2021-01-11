using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUI : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void MoveAbility()
    {
        gm.currentCharacter.GetComponent<Abilities>().SetCurrentAbility(0);
        gm.currentCharacter.GetComponent<Abilities>().CurrentAbility.DisplayRange();
    }
}
