﻿using System.Collections;
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
        
        Ray right = new Ray(transform.position, transform.right);
        CheckHit(right);
        
        Ray left = new Ray(transform.position, -transform.right); //this is how you do left, apparently :p
        CheckHit(left);
    }

    private void CheckHit(Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag(enemyTag))
            {
                this.gameObject.GetComponent<Movement>().SetDest(hit.collider.gameObject.GetComponent<Movement>().agent.destination);
                if (Vector3.Distance(transform.position, gameObject.GetComponent<Movement>().agent.destination) < 3f)
                {
                    Destroy(hit.collider.gameObject);
                    return;
                }
            }
        }
    }
}
