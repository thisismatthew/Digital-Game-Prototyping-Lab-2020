using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinMovement : Movement
{
    public override void SetDest(Vector3 goal)
    {
        agent.destination = goal;
    }
}
