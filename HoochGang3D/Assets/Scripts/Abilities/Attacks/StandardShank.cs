﻿using System.Collections;
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
        foreach (GameObject n in gm.nodes)
        {
            if (Vector3.Distance(transform.position, n.transform.position) <= range*6)
            {
                n.GetComponent<Node>().Highlight(attackMaterial);
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
        if (target.CompareTag(lineOfSight.enemyTag)) //target == enemy
        {
            Destroy(target);
        }
        else
        {
            foreach (GameObject c in gm.characters)
            {
                if (c != null)
                {
                    if (c.CompareTag("Adventurer") && c.GetComponent<Adventurer>().CurrentNode == target)
                    {
                        Destroy(c);
                        break;
                    }
                }
            }
        }
    }
}
