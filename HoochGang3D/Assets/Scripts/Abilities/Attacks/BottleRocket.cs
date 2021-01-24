using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRocket : Attack
{
    public GameObject projectile;
    private List<GameObject> nodesInRange;

    protected override void Start()
    {
        base.Start();
        isRanged = true;
        nodesInRange = new List<GameObject>();
    }

    public override void DisplayRange()
    {
        foreach (GameObject n in nm.nodes)
        {
            if (Vector3.Distance(transform.position, n.transform.position) <= range*6)
            {
                n.GetComponent<Node>().Highlight(attackMaterial);
                nodesInRange.Add(n);
            }
            else
            {
                n.GetComponent<Node>().ResetNode();
            }
        }
    }

    public override void Execute(GameObject _gameObject)
    {
        //find out if the game object is a node, or if the gameobject is a character
        if(_gameObject.GetComponent<Adventurer>() == null)
        {
            //Debug.Log("We have a node called: " + _gameObject.name + ". Converting to a character to shoot at");
            target = nodeToTarget(_gameObject);
        }
        else
        {
            //Debug.Log("We have a character called: " + _gameObject.name);
            target = _gameObject;
        }

        //Debug.Log(target);
        //Debug.Log("Bottle Rocket: firing at: " + target.name);
        //target = nodeToTarget(node);
        foreach(GameObject g in lineOfSight.GetTargetsInRange()) //loop through all targets we can see
        {
            //Debug.Log("Looping through game objects");
            if(target == g) //check if target we clicked on is one we can see
            {
                //Debug.Log("Can see a target");
                //check if target is within range
                if(Vector3.Distance(transform.position, target.transform.position) < range*6)
                {
                    //Debug.Log("Throwing hooch!");
                    GameObject firedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                    Projectile projectileScript = firedProjectile.GetComponent<Projectile>();
                    projectileScript.Seek(target.transform);
                }
            }
        }
    }
}
