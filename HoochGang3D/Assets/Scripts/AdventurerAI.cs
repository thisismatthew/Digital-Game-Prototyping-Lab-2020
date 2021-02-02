using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class AdventurerAI : MonoBehaviour
{
    private float range = 1;
    private GameObject target;
    private List<GameObject> nodesWithinRange = new List<GameObject>();
    public LineOfSight los;
    public GameObject projectile;

    public void Action(Adventurer adventurer)
    {
        Debug.Log("adventurer turn");
        GoToWell(adventurer);
    }

    private void GoToWell(Adventurer adventurer)
    {
        //the default action for the adventurer if theres no goblins in LoS is to move toward the well. 
        //set the target as the well, there is probably a better way to do this;
        foreach(GameObject node in adventurer.nm.nodes)
        {
            if (node.GetComponentsInChildren<Well>() != null) {
                target = node;
            }
        }

        //find all nodes within range
        //TODO check to make sure that the nodes arent occupied by walls or other characters. 
        foreach (GameObject n in adventurer.nm.nodes)
        {
            float dist = Vector3.Distance(n.transform.position, adventurer.transform.position);
            if (dist < range * 6 && dist > 1f)
            {
                nodesWithinRange.Add(n);
            }
        }

        GameObject closestNode = nodesWithinRange[0];
        float currentDist = 1000000;
        foreach (GameObject n in nodesWithinRange)
        {
            float newDist = Vector3.Distance(n.transform.position, target.transform.position);
            if (newDist < currentDist)
            {
                currentDist = newDist;
                closestNode = n;
            }
        }

        adventurer.GetComponent<NavMeshAgent>().destination = closestNode.transform.position;
        adventurer.currentNode = closestNode;
    }

    private void Attack()
    {
        if(los.GetTargetsInRange().Count == 0)
        {
            Debug.Log("No targets in range;");
            return;
        }
        else if(los.GetTargetsInRange().Count == 1)
        {
            GameObject target = los.GetTargetsInRange()[0];
            FireProjectile(target);
        }
        else if(los.GetTargetsInRange().Count > 1)
        {
            //randomly choose a target to shoot at
            GameObject target = los.GetTargetsInRange()[Random.Range(0,los.GetTargetsInRange().Count-1)];
            FireProjectile(target);
        }
    }

    private void FireProjectile(GameObject target)
    {
        if(Vector3.Distance(transform.position, target.transform.position) < range*6)
        {
            GameObject firedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            Projectile projectileScript = firedProjectile.GetComponent<Projectile>();
            projectileScript.Seek(target.transform);
        }
    }
}
