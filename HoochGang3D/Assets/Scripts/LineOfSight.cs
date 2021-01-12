using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private string enemyTag;
    [SerializeField]private float range;
    private Ray forward;

    private void Start()
    {
        range *= 5;

        if (gameObject.CompareTag("Goblin"))
        {
            enemyTag = "Adventurer";
        }
        else
        {
            enemyTag = "Goblin";
        }

        forward = new Ray(transform.position, transform.forward);
    }

    private void Update()
    {
        if (GetComponent<Movement>().agent.velocity != Vector3.zero) //only show line of sight when not moving
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ResetAllNodes();
            return;
        }

        CheckHit(forward);
    }

    private void CheckHit(Ray ray)
    {
        RaycastHit[] hits = Physics.RaycastAll(ray, range);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag("Detector"))
            {
                hits[i].collider.GetComponentInParent<Node>().Highlight();
                hits[i].collider.GetComponentInParent<Node>().InLineOfSight(i);
            }
        }
    }
}
