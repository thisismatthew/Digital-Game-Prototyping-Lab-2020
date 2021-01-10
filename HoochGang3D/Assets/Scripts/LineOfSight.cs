using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private string enemyTag;

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
        Ray forward = new Ray(transform.position, transform.forward);
        CheckHit(forward);

        if (gameObject.CompareTag("Goblin"))
        {
            Ray right = new Ray(transform.position, transform.right);
            CheckHit(right);

            Ray left = new Ray(transform.position, -transform.right); //this is how you do left, apparently :p
            CheckHit(left);
        }     
    }

    private void CheckHit(Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out RaycastHit hit, GetComponent<Movement>().GetRange() * 5f))
        {
            if (hit.collider.gameObject.CompareTag(enemyTag))
            {
                //tell gameobject to attack
                return;
            }
        }
    }
}
