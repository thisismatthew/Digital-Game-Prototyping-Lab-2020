using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerMovement : Movement
{ 
    protected override void Start()
    {
        base.Start(); //assigns NavMeshAgent and finds the GameManager script
        //if you decide the NavMesh is too problematic, just move it out of Movement and into GoblinMovement.
    }

    protected override void Update()
    {
        base.Update(); //sends the function back if gameobject is not currentCharacter
    }
}
