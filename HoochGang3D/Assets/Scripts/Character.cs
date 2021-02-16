using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //changed the protected to public for AI to access. 
    public GameObject currentNode;
    public TurnManager tm;
    public NodeManager nm;
    //for the moment characters just take a single "action" before it cycles to the next character.
    protected int actionsLeft;
    private bool turnTaken = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
        nm = GameObject.Find("GameManager").GetComponent<NodeManager>();
        GetNearestNode();
    }

    protected void GetNearestNode()
    {
        GameObject nearestNode = null;
        float shortDist = 99999;

        foreach (GameObject n in nm.nodes)
        {
            float dist = Vector3.Distance(transform.position, n.transform.position);
            if (dist < shortDist)
            {
                shortDist = dist;
                nearestNode = n;
            }
        }

        if(nearestNode == null)
        {
            Debug.Log(name + " does not have a current node");
        }

        GetComponent<Movement>().SetDest(nearestNode.transform.position);
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

    public bool TurnTaken { get => turnTaken; set => turnTaken = value; }
    public int ActionsLeft { get => actionsLeft; set => actionsLeft = value; }
}
