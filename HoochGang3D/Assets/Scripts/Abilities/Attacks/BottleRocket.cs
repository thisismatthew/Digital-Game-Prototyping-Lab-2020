using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRocket : Attack
{
    public override void DisplayRange()
    {
        
    }

    public override void Execute()
    {
        //find a target
        //check if that target is within line of sight and range
        //instantiate projectile that moves towards the target
        foreach(GameObject g in lineOfSight.GetTargetsInRange())
        {
            GameObject firedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            Projectile projectileScript = firedProjectile.GetComponent<Projectile>();
            projectileScript.Seek(g.transform);
        }
    }
}
