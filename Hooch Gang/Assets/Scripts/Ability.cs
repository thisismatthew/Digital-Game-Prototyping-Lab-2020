using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Ability : MonoBehaviour
{
    public int range;

    //these should be moved to a GameManager script later
    public TileBase originalTile;
    public TileBase inRangeTile;

    public void ShowRange(GameObject p, Tilemap t)
    {
        Vector3 nextTile = p.transform.position;
        t.SetTile(Vector3Int.FloorToInt(nextTile), inRangeTile);

        /*for (int i = 1; i <= range; i++) //x increasing
        {
            Vector3 nextTile = new Vector3(p.transform.position.x + i, p.transform.position.y, p.transform.position.z);
            t.SetTile(Vector3Int.FloorToInt(nextTile), inRangeTile);
        }
        
        for (int i = 1; i <= range; i++) //y increasing
        {
            Vector3 nextTile = new Vector3(p.transform.position.x, p.transform.position.y + i, p.transform.position.z);
            t.SetTile(Vector3Int.FloorToInt(nextTile), inRangeTile);
        }
        
        for (int i = 1; i >= -range; i--) //x decreasing
        {
            Vector3 nextTile = new Vector3(p.transform.position.x - i, p.transform.position.y, p.transform.position.z);
            t.SetTile(Vector3Int.FloorToInt(nextTile), inRangeTile);
        }
        
        for (int i = 1; i >= -range; i--) //y decreasing
        {
            Vector3 nextTile = new Vector3(p.transform.position.x, p.transform.position.y - i, p.transform.position.z);
            t.SetTile(Vector3Int.FloorToInt(nextTile), inRangeTile);
        }*/
    }
}
