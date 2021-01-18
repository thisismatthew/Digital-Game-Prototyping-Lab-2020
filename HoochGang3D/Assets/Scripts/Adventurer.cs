using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Adventurer : MonoBehaviour
{
    private GameManager gm;
    public GameObject currentNode;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetNearestNode();
    }

    /*private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
    }*/
    private void GetNearestNode()
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
