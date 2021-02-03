using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
public class Node : MonoBehaviour
{
    private Renderer rend;
    public Material startMaterial;
    public Material highlightMaterial;
    
    private TurnManager tm;
    private NodeManager nm;
    private NavMeshSurface surface;
    private bool isHighlighted;

    private void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
        nm = GameObject.Find("GameManager").GetComponent<NodeManager>();
        rend = GetComponent<Renderer>();
        surface = GetComponent<NavMeshSurface>();
        rend.material = startMaterial;

        if (transform.childCount > 1) //means it has an obstacle attached
        {
            surface.defaultArea = 1;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        //check if game is over
        if (tm.gameObject.GetComponent<GameManager>().gameIsOver)
        {
            return;
        }
        //check if target node is occupied
        if (IsNodeTaken() != null)
        {
            //if occupied by an ally, thats now selected as the current target
            tm.currentCharacter = IsNodeTaken();
            nm.ResetAllNodes();
            return;
        }
        //if the current character has no ability to execute, return. 
        if (tm.currentCharacter.GetComponent<Abilities>().CurrentAbility == null)
        {
            return;
        }
        //gotta be pointing at a gameobject
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //object is in range of the ability. 
        if (!IsNodeInRange())
        {
            return;
        }
        //execute the ability of the current character passing this node's gameobject
        tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Execute(gameObject);
        //goblins turns are ended after one action (atm). 
        tm.currentCharacter.GetComponent<Goblin>().TurnTaken = true;
        //cycle the character in the turn manager. 
        StartCoroutine(tm.NextCharacter());
    }

    private GameObject IsNodeTaken()
    {
        foreach (GameObject c in tm.goblins)
        {
            if (c != null && c.CompareTag(tm.currentCharacter.tag)) //make sure the character is alive and an ally
            {
                if (this.gameObject == c.GetComponent<Character>().CurrentNode) //if on this node
                {
                    return c;
                }
            }

        }

        return null;
    }

    public void Highlight(Material m)
    {
        if (surface.defaultArea == 1) //not walkable
        {
            return;
        }

        rend.material = m;
        isHighlighted = true;
    }

    public void ResetNode()
    {
        rend.material = startMaterial;
        isHighlighted = false;
    }

    private bool IsNodeInRange()
    {
        float dist = Vector3.Distance(transform.position, tm.currentCharacter.transform.position);
        if (dist < tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Range * 6f && dist > 3f)
        {
            return true;
        }
        return false;
    }

    /*private void OnMouseOver()
    {
        rend.material = highlightMaterial;
    }

    private void OnMouseExit()
    {
        rend.material = startMaterial;
    }*/

    public bool IsHighLighted
    {
        get { return isHighlighted; }
    }
}