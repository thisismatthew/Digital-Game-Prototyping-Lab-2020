using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Movement : Ability
{
    //does the agent actually move from here?
    public NavMeshAgent agent;
    public Material moveMaterial;

    protected override void Start()
    {
        base.Start();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {   
        if (gameObject != tm.currentCharacter)
        {
            return;
        }
    }

    public virtual void SetDest(Vector3 goal) { }
}
