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

    private void CheckHit()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        Vector3 charToColl;
        float dot;

        foreach (Collider c in hits)
        {
            charToColl = (c.transform.position - transform.position).normalized;
            dot = Vector3.Dot(charToColl, transform.forward);
            if (dot >= Mathf.Cos(45) && c.CompareTag("Detector"))
            {
                c.gameObject.GetComponentInParent<Node>().Highlight();
            }
        }
    }
}
