using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMovement : Ability
{
    public Tilemap map;
    private Vector3 destination;

    [SerializeField] private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ShowRange(gameObject, map);

        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }
        if (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
        }
    }

    private void MouseClick()
    {
        Vector2 mousePosition = Input.mousePosition; //Vector 2 to Vector 3?
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if (map.HasTile(gridPosition))
        {
            destination = mousePosition;
        }
    }
}
