using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD:HoochGang3D/Assets/Scripts/Abilities/Attacks/Attack.cs
public abstract class Attack : Ability
{
    public GameObject projectile;
    private GameObject target;
    private LineOfSight lineOfSight;

    protected override void Start()
    {
        //get the line of sight component
        lineOfSight = gameObject.GetComponent<LineOfSight>();
=======
public class BottleRocket : Attack
{
    public override void DisplayRange()
    {
        //TODO: Display ranged once the range has been determined
        //Debug.Log("Displaying Range");
>>>>>>> d6fde0bf84c6543f22d30ed76d5813157f4bf703:HoochGang3D/Assets/Scripts/Abilities/Attacks/BottleRocket.cs
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

    public GameObject Target
    {
        get { return target; }
        set
        {
            if (value.CompareTag(GetComponent<LineOfSight>().enemyTag))
            {
                target = value;
            }   
        }
    }
}
