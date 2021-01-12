using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Movement : Ability
{
    public NavMeshAgent agent;
    protected GameManager gm;

    protected override void Start()
    {
        base.Start();
        agent = gameObject.GetComponent<NavMeshAgent>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
