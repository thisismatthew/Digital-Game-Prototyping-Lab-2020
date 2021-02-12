using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardShank : Attack
{
    private List<GameObject> nodesInRange;

    protected override void Start()
    {
        base.Start();
        range = 1.5f;
        isRanged = false;
        nodesInRange = new List<GameObject>();
    }
    public override void DisplayRange()
    {
        foreach (GameObject n in nm.nodes)
        {
            if (Vector3.Distance(transform.position, n.transform.position) <= range*6)
            {
                n.GetComponent<Node>().SpriteHighlight(Color.red);
                nodesInRange.Add(n);
            }
            else
            {
                n.GetComponent<Node>().ResetNode();
            }
        }
    }

    public override void Execute(GameObject target)
    {

        if (target.CompareTag("Adventurer"))
        {
            Destroy(target);
            GetComponent<Goblin>().ActionsLeft -= 1;
        }
        else
        {
            foreach (GameObject c in tm.adventurers)
            {
                if (c != null)
                {
                    if (c.GetComponent<Character>().CurrentNode == target)
                    {
                        Destroy(c);
                        GetComponent<Goblin>().ActionsLeft -= 1;
                        break;
                    }
                }
            }
        }
    }
}
