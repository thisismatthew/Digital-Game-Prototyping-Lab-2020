using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinMovement : Movement
{
    public override void DisplayRange()
    {
        foreach (GameObject n in gm.nodes)
        {
            float dist = Vector3.Distance(n.transform.position, transform.position);

            if (dist < range * 6 && dist > 1f)
            {
                n.GetComponent<Node>().Highlight(moveMaterial);
                continue;
            }

            n.GetComponent<Node>().ResetNode();
        }
        
    }

    public override void Execute(GameObject goal)
    {
        //here there would be a pathfinding call that returns a list of the points that the agent needs to go to
        //next it would call a "Movement" or linear interpolation towards each of the points until the list has been completed. 
        agent.destination = goal.transform.position;
        gameObject.GetComponent<Goblin>().CurrentNode = goal;
    }
}
