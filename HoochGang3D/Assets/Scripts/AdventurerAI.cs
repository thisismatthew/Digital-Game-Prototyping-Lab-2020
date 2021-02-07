using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class AdventurerAI : MonoBehaviour
{
    public float movementRange = 1;
    private GameObject target;
    private List<GameObject> nodesWithinRange = new List<GameObject>();
    public LineOfSight los;
    public GameObject projectile;
    private List<GameObject> targetsWithinRange;
    private TurnManager tm;

    public void Update()
    {
        targetsWithinRange = los.GetTargetsInRange();
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
        //Debug.Log(targetsWithinRange.Count);
    }

    public void Action(Adventurer adventurer)
    {
        Debug.Log("adventurer turn");
        if(targetsWithinRange.Count > 0)
        {
            float decision = Random.Range(0,2);
            if(decision == 0)
            {   
                //the first goal oriented behaviour, go to the well and destroy any goblins on the way
                GoToWell(adventurer);
                CheckForTarget(); //check to see if there is a target to attack
            }
            else if(decision == 1)
            {
                //The second goal will seek out a goblin it can see and attack it
                ChaseGoblin(adventurer);
                CheckForTarget(); //check to see if there is a target to attack
            }
        }
        else
        {
            //the first goal oriented behaviour, go to the well and destroy any goblins on the way
            GoToWell(adventurer);
            CheckForTarget(); //check to see if there is a target to attack
        }
    }

    private void GoToWell(Adventurer adventurer)
    {
        //the default action for the adventurer if theres no goblins in LoS is to move toward the well. 
        //set the target as the well, there is probably a better way to do this;
        target = GameObject.FindGameObjectWithTag("Well");

        //find all nodes within range
        //TODO check to make sure that the nodes arent occupied by walls or other characters. 
        foreach (GameObject n in adventurer.nm.nodes)
        {
            float dist = Vector3.Distance(n.transform.position, adventurer.transform.position);
            if (dist < movementRange * 6 && dist > 1f)
            {
                if (n.transform.childCount < 2) // checks there is no obstacle child
                {
                    nodesWithinRange.Add(n);
                }
            }
        }

        //dont move to the same tile as another adventurer
        foreach (GameObject c in adventurer.tm.adventurers)
        {
            if (nodesWithinRange.Contains(c.GetComponent<Character>().CurrentNode))
            {
                nodesWithinRange.Remove(c.GetComponent<Character>().CurrentNode);
            }
        }

        //dont move to the same tile as a goblin
        foreach (GameObject c in adventurer.tm.goblins)
        {
            if (nodesWithinRange.Contains(c.GetComponent<Character>().CurrentNode))
            {
                nodesWithinRange.Remove(c.GetComponent<Character>().CurrentNode);
            }
        }

        GameObject closestNode = nodesWithinRange[0];
        float currentDist = Mathf.Infinity;
        foreach (GameObject n in nodesWithinRange)
        {
            float newDist = Vector3.Distance(n.transform.position, target.GetComponentInParent<Transform>().position);
            if (newDist < currentDist)
            {
                currentDist = newDist;
                closestNode = n;
            }
        }

        adventurer.GetComponent<NavMeshAgent>().destination = closestNode.transform.position;
        adventurer.currentNode = closestNode;
    }

    private void ChaseGoblin(Adventurer a)
    {
        //Debug.Log("Chasing goblin... soon");
        //first check if we can see a goblin
        if(targetsWithinRange.Count == 0)
        {
            //No targets to chase.
            Debug.Log("Somehow we lost some targets before we could chase them.");
        }
        else if(targetsWithinRange.Count == 1) //if we can see a goblin, move toward it
        {
            MoveTo(a, targetsWithinRange[0].transform);
        }
        else if(targetsWithinRange.Count > 1) //if there is more than one goblin, select one to move to at random
        {
            MoveTo(a, targetsWithinRange[Random.Range(0, targetsWithinRange.Count)].transform);
        }
    }

    private void MoveTo(Adventurer a, Transform t)
    {
        //modified version of GoToWell that takes in a transform instead of finding the well

        //find all nodes within range
        //TODO check to make sure that the nodes arent occupied by walls or other characters. 
        foreach (GameObject n in a.nm.nodes)
        {
            float dist = Vector3.Distance(n.transform.position, a.transform.position);
            if (dist < movementRange * 6 && dist > 1f)
            {
                if (n.transform.childCount < 2) // checks there is no obstacle child
                {
                    nodesWithinRange.Add(n);
                }
            }
        }

        //dont move to the same tile as another adventurer
        foreach (GameObject c in a.tm.adventurers)
        {
            if (nodesWithinRange.Contains(c.GetComponent<Character>().CurrentNode))
            {
                nodesWithinRange.Remove(c.GetComponent<Character>().CurrentNode);
            }
        }

        //dont move to the same tile as a goblin
        foreach (GameObject c in a.tm.goblins)
        {
            if (nodesWithinRange.Contains(c.GetComponent<Character>().CurrentNode))
            {
                nodesWithinRange.Remove(c.GetComponent<Character>().CurrentNode);
            }
        }

        GameObject closestNode = nodesWithinRange[0];
        float currentDist = Mathf.Infinity;
        foreach (GameObject n in nodesWithinRange)
        {
            float newDist = Vector3.Distance(n.transform.position, t.position);
            if (newDist < currentDist)
            {
                currentDist = newDist;
                closestNode = n;
            }
        }

        a.GetComponent<NavMeshAgent>().destination = closestNode.transform.position;
        a.currentNode = closestNode;
        StartCoroutine(tm.NextCharacter()); //move to next character
    }

    private void CheckForTarget()
    {
        if(targetsWithinRange.Count == 0) //line of sight can't see any targets
        {
            Debug.Log("No targets in range;");
            return;
        }
        else if(targetsWithinRange.Count == 1)//line of sight can only see one target
        {
            ChooseAttackType(targetsWithinRange[0]);//object at index 0 is the only target we can see
        }
        else if(targetsWithinRange.Count > 1)//there is more than one target within ine of sight
        {
            //select the closest target to attack
            float shortestDistance = Mathf.Infinity;//set shortest distance to infinity
            foreach(GameObject g in targetsWithinRange)
            {
                float distanceToGameObject = Vector3.Distance(transform.position, target.transform.position);//calculate distance between us and the other object
                if(distanceToGameObject < shortestDistance)//always runs the first time since shortestdistance in infinite
                {
                    shortestDistance = distanceToGameObject;
                }
            }

            //now that we have the shortest distance, we find all the characters that are that far from us and store them in a list
            List<GameObject> gameObjectsWithShortestRange = new List<GameObject>();
            foreach(GameObject g in targetsWithinRange)
            {
                if(Vector3.Distance(transform.position, target.transform.position) == shortestDistance)
                {
                    gameObjectsWithShortestRange.Add(g);
                }
            }

            if(gameObjectsWithShortestRange.Count > 1)//if more than one unit is the same distance away from us eg. two units are tied to being the closest
            {
                ChooseAttackType(gameObjectsWithShortestRange[Random.Range(0,gameObjectsWithShortestRange.Count-1)]);//choose randomly
            }
            else if(gameObjectsWithShortestRange.Count == 1)//if there is only one unit that is the closest to us
            {
                ChooseAttackType(gameObjectsWithShortestRange[0]);//the only one in the list
            }
            else
            {
                Debug.Log("Something went wrong with distance calulcation during attack target selection.");
            }
            //FireProjectile(targetsWithinRange[Random.Range(0,targetsWithinRange.Count-1)].transform);
        }
        else
        {
            Debug.Log("Something went wrong when using adventurer ai used line of sight");
        }
    }

    private void ChooseAttackType(GameObject target)
    {
        //check how far away the target is
        if(Vector3.Distance(transform.position, target.transform.position) < 6)//if it's within melee range, perform a melee attack
        {
            MeleeAttack(target);
        }
        else if(Vector3.Distance(transform.position, target.transform.position) < los.Range*6) //if it's not within melee range, perform a ranged attack
        {
            //Debug.Log("Target within line of sight");
            FireProjectile(target.transform);
        }
    }

    private void MeleeAttack(GameObject target)
    {
        //works similarly to shank
        Debug.Log("Melee attack");
        Destroy(target);
        StartCoroutine(tm.NextCharacter()); //move to next character
    }

    private void FireProjectile(Transform target)
    {
        //works similarly to bottle rocket, but uses the range on line of sight
        if(Vector3.Distance(transform.position, target.position) < los.Range*6) //sight range and shooting range are the same, if the ai can see you, it will shoot you
        {
            GameObject firedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            Projectile projectileScript = firedProjectile.GetComponent<Projectile>();
            projectileScript.Seek(target);
            StartCoroutine(tm.NextCharacter()); //move to next character
        }
    }
}
