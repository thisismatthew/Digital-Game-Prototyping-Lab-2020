using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRocket : Attack
{
    public override void DisplayRange()
    {
        //TODO: Display ranged once the range has been determined
        //Debug.Log("Displaying Range");
    }

    public override void Execute()
    {
        foreach(GameObject g in lineOfSight.GetTargetsInRange()) //find all targets within line of sight
        {
            //check if target is within range
            
            //instantiate projectile
            GameObject firedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            Projectile projectileScript = firedProjectile.GetComponent<Projectile>();
            projectileScript.Seek(g.transform);
        }
    }
}
