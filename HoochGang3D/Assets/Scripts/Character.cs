using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private NavMeshAgent agent;
    private Renderer rend;
    private Color startColor;
    public bool selected = false;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        rend = gameObject.GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void Update()
    {
        if(selected)
        {
            //visually indicate that this agent has been selected
            rend.material.color = Color.green;
        }
        else
        {
            rend.material.color = startColor;
        }
    }

    public void SetDest(Vector3 goal)
    {
        agent.destination = goal;
    }
}
