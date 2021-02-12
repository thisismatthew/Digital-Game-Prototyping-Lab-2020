using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Movement : Ability
{
    //does the agent actually move from here?
    public NavMeshAgent agent;
    public Material moveMaterial;
    public Color moveColor;

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

    protected void SnapToIsometricAxis()
    {
        //transform.Rotate(0, Snapping.Snap(transform.rotation.y, 90), 0);
        transform.eulerAngles = new Vector3(0, Snapping.Snap(transform.rotation.y, 90), 0);
    }
}
