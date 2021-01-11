using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUI : MonoBehaviour
{
    private GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();


    private void MoveAbility()
    {
        gm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null; //move;
    }
}
