using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    private Renderer rend;
    public Material startMaterial;
    public Material highlightMaterial;

    private float dist;
    private GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rend = GetComponent<Renderer>();
        rend.material = startMaterial;
    }

    private void Update()
    {
        dist = Vector3.Distance(gm.currentCharacter.GetComponent<Movement>().agent.destination, transform.position);

        if (dist < gm.currentCharacter.GetComponent<Movement>().range * 6 && dist > 1f)
        {
            rend.material = highlightMaterial;
            return;
        }

        rend.material = startMaterial;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (IsNodeTaken() != null)
        {
            gm.currentCharacter = IsNodeTaken();
            return;
        }
        if (Vector3.Distance(transform.position, gm.currentCharacter.GetComponent<Movement>().agent.destination) > gm.currentCharacter.GetComponent<Movement>().range * 6)
        {
            return;
        }

        gm.currentCharacter.GetComponent<Movement>().SetDest(transform.position);
        gm.NextCharacter();
    }

    private GameObject IsNodeTaken()
    {
        foreach (GameObject c in gm.characters)
        {
            if (c != null)
            {
                if (Vector3.Distance(c.transform.position, this.gameObject.transform.position) < 3.0f && c.CompareTag(gm.currentCharacter.tag))
                {
                    return c;
                }
            }
            
        }

        return null;
    }
}
