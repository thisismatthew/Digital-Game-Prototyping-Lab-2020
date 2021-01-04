using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private NavMeshAgent agent;
    [HideInInspector]public Transform goal;
    public Transform startPoint;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        goal = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = goal.position;
    }
}
