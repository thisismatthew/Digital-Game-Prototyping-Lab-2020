using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambush : MonoBehaviour
{
    private TurnManager tm;

    void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
    }

    public void Execute()
    {
        foreach (GameObject c in tm.characters)
        {
            if (c.CompareTag("Goblin") && c.GetComponent<LineOfSight>().GetTargetsInRange().Count > 0)
            {
                c.GetComponent<Attack>().Target = GetNearestTarget(c);
            }
        }
        
    }

    private GameObject GetNearestTarget(GameObject c)
    {
        float shortDist = 99999;
        GameObject target = null;
        foreach (GameObject e in c.GetComponent<LineOfSight>().GetTargetsInRange())
        {
            float dist = Vector3.Distance(c.transform.position, e.transform.position);
            if (dist < shortDist && dist <= c.GetComponent<Movement>().Range * 6) //get closest enemy that is also in range
            {
                shortDist = dist;
                foreach (GameObject g in tm.characters)
                {
                    if (g.CompareTag("Goblin") && g.GetComponent<Attack>().Target == target)
                    {
                        break;
                    }
                    else
                    {
                        target = e;
                    }
                }
            }
        }

        return target;
    }
    
}
