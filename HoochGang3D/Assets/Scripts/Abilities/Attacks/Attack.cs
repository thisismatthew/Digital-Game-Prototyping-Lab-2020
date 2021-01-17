using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Ability
{
    public GameObject projectile;
    protected LineOfSight lineOfSight;

    protected override void Start()
    {
        //get the line of sight component
        lineOfSight = gameObject.GetComponent<LineOfSight>();
    }
}
