using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
public class Node : MonoBehaviour
{
    private Renderer rend;
    public Material startMaterial;
    public Material highlightMaterial;

    private GameManager gm;
    private NavMeshSurface surface;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            gm.SelectCharacter(IsNodeTaken());
            gm.ResetAllNodes();
            return;
        }
        if (gm.currentCharacter.GetComponent<Abilities>().CurrentAbility == null)
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

        gm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Execute(transform.position);
        gm.NextCharacter();
    }

    private GameObject IsNodeTaken()
    {
        foreach (GameObject c in gm.characters)
        {
            if (c != null)
            {
                float dist = Vector3.Distance(c.transform.position, this.gameObject.transform.position);
                if (dist < 3.0f && c.CompareTag(gm.currentCharacter.tag))
                {
                    return c;
                }
            }

        }

        return null;
    }

    public void Highlight()
    {
        if (surface.defaultArea == 1) //not walkable
        {
            return;
        }

        rend.material = highlightMaterial;
    }

    public void ResetNode()
    {
        rend.material = startMaterial;
    }

    private bool IsNodeInRange()
    {
        float dist = Vector3.Distance(transform.position, gm.currentCharacter.transform.position);
        if (dist < gm.currentCharacter.GetComponent<Abilities>().CurrentAbility.Range * 6f && dist > 3f)
        {
            return true;
        }
        return false;
    }

}