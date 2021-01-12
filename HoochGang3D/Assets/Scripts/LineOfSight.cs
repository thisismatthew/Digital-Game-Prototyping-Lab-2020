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
        if (GetComponent<Movement>().agent.velocity != Vector3.zero) //only show line of sight when not moving, prevents entire grid from being highlighted
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ResetAllNodes();
            return;
        }

        Ray forward = new Ray(transform.position, transform.forward); //agent looks forward
        CheckHit(forward);
    }

    private void CheckHit(Ray ray)
    {
        RaycastHit[] hits = Physics.RaycastAll(ray, range * 5); //get every gameobject it hits

        foreach (RaycastHit hit in hits)
        {
            if (!hit.collider.CompareTag("Detector") && !hit.collider.CompareTag(enemyTag)) //ignore obstacles
            {
                continue;
            }

            //add if statement for raycast hitting an enemy

            if (hit.collider.CompareTag("Detector")) //if it hits a detector, highlight the node
            {
                hit.collider.GetComponentInParent<Node>().Highlight();
                continue;
            }
        }
    }
}
