using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 prevPoint;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        prevPoint = agent.destination;
    }

    public void SetDest(Transform newGoal)
    {
        agent.destination = newGoal.position;
    }
}
