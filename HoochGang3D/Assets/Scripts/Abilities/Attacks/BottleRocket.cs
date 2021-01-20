using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRocket : Attack
{
    public GameObject projectile;

    protected override void Start()
    {
        base.Start();
        isRanged = true;
    }

    public override void DisplayRange()
    {
        //TODO: Display ranged once the range has been determined
        Debug.Log("Displaying Range");
    }

    public override void Execute(GameObject node)
    {
        Debug.Log("Started attack");
        target = nodeToTarget(node); //sets the target to 
        foreach(GameObject g in lineOfSight.GetTargetsInRange()) //loop through all targets we can see
        {
            Debug.Log("Looping through game objects");
            if(target == g) //check if target we clicked on is one we can see
            {
                Debug.Log("Can see a target");
                //check if target is within range
                if(Vector3.Distance(transform.position, target.transform.position) < range)
                {
                    Debug.Log("Throwing hooch!");
                    GameObject firedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                    Projectile projectileScript = firedProjectile.GetComponent<Projectile>();
                    projectileScript.Seek(target.transform);
                }
            }
        }
    }
}
