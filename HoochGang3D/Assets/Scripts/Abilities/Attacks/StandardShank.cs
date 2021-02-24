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
                //n.GetComponent<Node>().Highlight(attackMaterial);
                n.GetComponent<Node>().SpriteHighlight(attackColor);
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
        base.Execute();
        if (target.CompareTag("Adventurer"))
        {
            target.gameObject.GetComponentInChildren<Animator>().Play("Adventurer_Death_1");
            Destroy(target, 3f);
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
                        target.gameObject.GetComponentInChildren<Animator>().Play("Adventurer_death");
                        Destroy(target, 3f);
                        GetComponent<Goblin>().ActionsLeft -= 1;
                        break;
                    }
                }
            }
        }
    }
}
