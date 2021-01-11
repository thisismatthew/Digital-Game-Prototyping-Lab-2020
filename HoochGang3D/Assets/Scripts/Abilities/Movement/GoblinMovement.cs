using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinMovement : Movement
{
    protected override void DisplayRange()
    {
        foreach (GameObject n in gm.nodes)
        {
            float dist = Vector3.Distance(n.transform.position, transform.position);

            if (dist < range * 6 && dist > 1f)
            {
                n.GetComponent<Node>().HighlightNode();
                continue;
            }

            n.GetComponent<Node>().ResetNode();
        }
        
    }

    public override void SetDest(Vector3 goal)
    {
        agent.destination = goal;
    }
}
