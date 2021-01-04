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
            gm.currentCharacter = IsNodeTaken();
            return;
        }

        gm.currentCharacter.GetComponent<Movement>().goal = this.gameObject.transform;
        gm.NextCharacter();
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
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
            if (Vector3.Distance(c.transform.position, this.gameObject.transform.position) < 3.0f)
            {
                return c;
            }
        }

        return null;
    }
}
