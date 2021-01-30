using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [HideInInspector]public Graph graph;
    [HideInInspector]public GameObject[] nodes;

    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("Node");
        graph = new Graph(nodes);
    }

    public void ResetAllNodes()
    {
        foreach (GameObject n in nodes)
        {
            n.GetComponent<Node>().ResetNode();
            n.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
