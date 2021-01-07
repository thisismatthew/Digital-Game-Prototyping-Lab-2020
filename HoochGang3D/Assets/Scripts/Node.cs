using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Material hoverMaterial;
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;
    private Material startMaterial;

    [SerializeField] private GameManager gm;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        startMaterial = rend.material;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (IsNodeTaken() != null)
        {
            gm.ResetNodes();
            gm.currentCharacter = IsNodeTaken();
            return;
        }
        if (Vector3.Distance(transform.position, gm.currentCharacter.GetComponent<Movement>().currentNode.transform.position) > gm.currentCharacter.GetComponent<Movement>().range * 5)
        {
            return;
        }

        gm.currentCharacter.GetComponent<Movement>().SetDest(this.transform.position);
        gm.NextCharacter();
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Vector3.Distance(transform.position, gm.currentCharacter.GetComponent<Movement>().currentNode.transform.position) > gm.currentCharacter.GetComponent<Movement>().range * 5)
        {
            return;
        }
        
        //rend.material.color = Color.green;
        rend.material = hoverMaterial;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        rend.material = startMaterial;
    }

    private GameObject IsNodeTaken()
    {
        foreach (GameObject c in gm.characters)
        {
            if (c != null)
            {
                if (Vector3.Distance(c.transform.position, this.gameObject.transform.position) < 3.0f)
                {
                    return c;
                }
            }
            
        }

        return null;
    }

    public void SetRenderer(Material mat)
    {
        rend.material = mat;
    }
}
