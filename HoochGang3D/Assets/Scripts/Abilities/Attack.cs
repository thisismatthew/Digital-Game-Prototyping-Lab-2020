using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Ability
{
    public GameObject projectile;
    private LineOfSight lineOfSight;

    protected override void Start()
    {
        //get the line of sight component
        lineOfSight = gameObject.GetComponent<LineOfSight>();
    }

    public override void DisplayRange()
    {
        
    }

    public override void Execute(Vector3 target)
    {
        //find a target
        //check if that target is within line of sight and range
        //instantiate projectile that moves towards the target
    }
}
