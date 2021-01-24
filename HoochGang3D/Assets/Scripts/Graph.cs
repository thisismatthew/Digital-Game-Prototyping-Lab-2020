using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Graph 
{
    public List<List<GameObject>> graph;
    public Graph(GameObject[] nodes)
    {
        graph = new List<List<GameObject>>();
        int column = 0;
        graph.Add(new List<GameObject>());

        foreach (GameObject node in nodes)
        {
            //this only works if the nodes are placed in scene from left to right, 
            if (node.transform.position.x > nodes[0].transform.position.x)
            {
                graph[column].Add(nodes[0]);
            }
            else
            {
                graph.Add(new List<GameObject>());
                column++;
                graph[column].Add(nodes[0]);
            }
        }
    }
    public Tuple<int, int> NodeToTuple(GameObject target)
    {
        for (int i = 0; i < graph.Count; i++)
        {
            for (int j = 0; j < graph[i].Count; j++)
            {
                if (graph[i][j].transform.position == target.transform.position)
                {
                    return new Tuple<int, int>(i, j);
                }
            }
        }
        Debug.Log("Target not found in grid moving to cell [0,0]");
        return new Tuple<int, int>(0, 0);
    }

}
