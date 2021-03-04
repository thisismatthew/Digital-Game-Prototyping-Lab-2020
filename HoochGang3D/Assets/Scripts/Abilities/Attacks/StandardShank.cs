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
        if(FacingAway(target.transform))
            gameObject.GetComponentInChildren<Animator>().Play("goblin_melee");
        else
            gameObject.GetComponentInChildren<Animator>().Play("goblin_melee_away");

        base.Execute();
        if (target.CompareTag("Adventurer"))
        {
            
            FindObjectOfType<AudioManager>().Play("Melee_Attack");
            target.gameObject.GetComponentInChildren<Animator>().Play("Adventurer_death");
            FindObjectOfType<AudioManager>().Play("Adventurer_Death_1");

            //Destroy(target, 3f);
            Projectile.Kill(target.transform);
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
                        FindObjectOfType<AudioManager>().Play("Melee_Attack");
                        target.gameObject.GetComponentInChildren<Animator>().Play("Adventurer_death");
                        FindObjectOfType<AudioManager>().Play("Adventurer_Death_2");

                        //Destroy(target, 3f);
                        Projectile.Kill(target.transform);
                        GetComponent<Goblin>().ActionsLeft -= 1;
                        break;
                    }
                }
            }
        }
    }

    private bool FacingAway(Transform target)
    {
        if ((transform.position.x < target.position.x) || (transform.position.z < target.position.z))
            return false;
        else
            return true;
    }
}
