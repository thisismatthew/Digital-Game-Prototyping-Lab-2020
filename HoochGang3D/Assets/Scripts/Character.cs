using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected GameObject currentNode;
    protected GameManager gm;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetNearestNode();
    }

    protected void GetNearestNode()
    {
        GameObject nearestNode = null;
        float shortDist = 99999;

        foreach (GameObject n in gm.nodes)
        {
            float dist = Vector3.Distance(transform.position, n.transform.position);
            if (dist < shortDist)
            {
                shortDist = dist;
                nearestNode = n;
            }
        }

        currentNode = nearestNode;
    }

    public GameObject CurrentNode
    {
        set
        {
            currentNode = value;
        }
        get
        {
            return currentNode;
        }
    }
}
