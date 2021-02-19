using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : Ability
{
    public override void Execute() 
    {
        base.Execute();
        PassTurn();
    }

    public override void Execute(GameObject node)
    {
        base.Execute();
        PassTurn();
    }

    private void PassTurn()
    {
        GetComponent<Character>().ActionsLeft = 0;
        StartCoroutine(GameObject.Find("GameManager").GetComponent<TurnManager>().NextCharacter());
    }
}
