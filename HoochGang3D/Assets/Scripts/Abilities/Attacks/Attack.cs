using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Ability
{
    public Material attackMaterial;
    protected GameObject target;
    protected LineOfSight lineOfSight;
    [HideInInspector]public bool isRanged;

    protected override void Start()
    {
        base.Start();
        lineOfSight = gameObject.GetComponent<LineOfSight>();
        isAttack = true;
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
