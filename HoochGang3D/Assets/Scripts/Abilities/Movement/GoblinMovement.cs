using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinMovement : Movement
{
    public override void DisplayRange()
    {
        foreach (GameObject n in nm.nodes)
        {
            float dist = Vector3.Distance(n.transform.position, transform.position);

            if (dist < range * 6 && dist > 1f)
            {
                //n.GetComponent<Node>().Highlight(moveMaterial);
                n.GetComponent<Node>().SpriteHighlight(moveColor);
                continue;
            }

            n.GetComponent<Node>().ResetNode();
        }
        
    }

    public override void Execute(GameObject goal)
    {
        agent.destination = goal.transform.position;
        gameObject.GetComponent<Goblin>().CurrentNode = goal;
        GetComponent<Goblin>().ActionsLeft -= 1;
    }
}
