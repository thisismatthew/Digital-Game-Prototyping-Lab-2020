using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Movement : Ability
{
    public NavMeshAgent agent;

    protected override void Start()
    {
        base.Start();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {   
        if (gameObject != gm.currentCharacter)
        {
            return;
        }
    }

    public virtual void SetDest(Vector3 goal) { }
}
