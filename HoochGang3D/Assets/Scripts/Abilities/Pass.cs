using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : Ability
{
    public override void Execute() 
    {
        PassTurn();
    }

    public override void Execute(GameObject node)
    {
        PassTurn();
    }

    private void PassTurn()
    {
        Debug.Log("Passed Turn");
        StartCoroutine(GameObject.Find("GameManager").GetComponent<TurnManager>().NextCharacter());
    }
}
