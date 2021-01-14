using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private string enemyTag;
    [SerializeField]private float range;

    private void Start()
    {
        if (gameObject.CompareTag("Goblin"))
        {
            enemyTag = "Adventurer";
        }
        else
        {
            enemyTag = "Goblin";
        }
    }

    private void Update()
    {
        if (GetComponent<Movement>().agent.velocity != Vector3.zero) //only show line of sight when not moving
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ResetAllNodes();
            return;
        }

        CheckHit();
    }

    private Collider[] getCollisions()
    {
        Collider[] result = Physics.OverlapSphere(transform.position, range);
        return result;
    }

    private void CheckHit()
    {
        Vector3 charToColl;
        float dot;

        foreach (Collider c in getCollisions())
        {
            charToColl = (c.transform.position - transform.position).normalized;
            dot = Vector3.Dot(charToColl, transform.forward);
            if (dot >= Mathf.Cos(45) && c.CompareTag("Detector"))
            {
                c.gameObject.GetComponentInParent<Node>().Highlight();
            }
        }
    }

    public List<GameObject> GetTargetsInRange()
    {
        List<GameObject> result = new List<GameObject>();

        //add those with our enemytag to the result
        foreach (Collider c in getCollisions())
        {
            if(c.tag == enemyTag)
            {
                result.Add(c.gameObject);
            }
        }
            
        return result;
    }
}
