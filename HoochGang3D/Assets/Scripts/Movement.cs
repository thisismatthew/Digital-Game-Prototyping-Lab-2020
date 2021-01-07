using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject currentNode;
    private GameManager gm;
    public int range;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gameObject != gm.currentCharacter)
        {
            return;
        }

        currentNode = FindNearestNode();
    }

    public void SetDest(Vector3 goal)
    {
        agent.destination = goal;
    }

    private GameObject FindNearestNode()
    {
        foreach (GameObject n in gm.nodes)
        {
            if (Vector3.Distance(n.transform.position, transform.position) < 3.0f)
            {
                return n;
            }
        }

        return null;
    }
}
