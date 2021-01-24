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
        if (IsNodeTaken() != null)
        {
            tm.currentCharacter = IsNodeTaken();
            nm.ResetAllNodes();
            return;
        }
        if (tm.currentCharacter.GetComponent<Abilities>().CurrentAbility == null)
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!IsNodeInRange())
        {
            return;
        }

        tm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Execute(gameObject);
        tm.NextCharacter();
    }

    private GameObject IsNodeTaken()
    {
        foreach (GameObject c in tm.characters)
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
    }

    public void ResetNode()
    {
        rend.material = startMaterial;
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
}