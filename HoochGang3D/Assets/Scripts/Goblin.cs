﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Goblin : MonoBehaviour
{
    public GameObject agentUI;
    private GameManager gm;
    private GameObject currentNode;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetNearestNode();
    }

    private void Update()
    {
        if (gm.currentCharacter == this.gameObject)
        {
            agentUI.SetActive(true);
            return;
        }

        agentUI.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!gm.currentCharacter.CompareTag(gameObject.tag))
        {
            return;
        }

        gm.currentCharacter = this.gameObject;
    }

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
        set { currentNode = value; }
        get{ return currentNode; }
    }
}
