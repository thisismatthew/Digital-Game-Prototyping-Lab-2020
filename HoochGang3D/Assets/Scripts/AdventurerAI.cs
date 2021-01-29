using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AdventurerAI : MonoBehaviour
{
    private TurnManager tm;

    private void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
    }

    //this script will be filled out with a proper ai for the adventurers. 
    public void TakeTurn()
    {
        tm.NextCharacter();
    }
}
