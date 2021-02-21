using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NodeManager : MonoBehaviour
{
    [HideInInspector]public GameObject[] nodes;

    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("Node");
    }

    public void ResetAllNodes()
    {
        foreach (GameObject n in nodes)
        {
            if (n.GetComponent<NavMeshSurface>().defaultArea != 1)
            {
                n.GetComponent<Node>().ResetNode();
                n.transform.Find("Detector").gameObject.SetActive(true);
            }
        }
    }
}
