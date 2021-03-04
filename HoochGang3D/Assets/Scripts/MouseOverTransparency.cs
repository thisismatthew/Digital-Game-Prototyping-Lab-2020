using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverTransparency : MonoBehaviour
{
    public GameObject buildingSprite;
    public Color startColor;
    public Color mouseOverColor;
    bool mouseOver = false;

    private void Start()
    {
        startColor = buildingSprite.GetComponent<Renderer>().material.GetColor("_Color");
    }

    private void OnMouseEnter()
    {
        mouseOver = true;
        buildingSprite.GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        buildingSprite.GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }
}
