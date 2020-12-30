using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;

    [SerializeField] private GameManager gm;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        gm.currentCharacter.GetComponent<Movement>().goal = this.gameObject.transform;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        
        rend.material.color = Color.green;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
