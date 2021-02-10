using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRocket : Attack
{
    public GameObject projectile;
    private List<GameObject> nodesInRange;

    protected override void Start()
    {
        base.Start();
        isRanged = true;
        nodesInRange = new List<GameObject>();
    }

    public override void DisplayRange()
    {
        foreach (GameObject n in nm.nodes)
        {
            if (Vector3.Distance(transform.position, n.transform.position) <= range*6)
            {
                Node node = n.GetComponent<Node>();
                /*if(node.IsHighLighted)
                {
                    node.Highlight(attackMaterial);
                }*/
                node.Highlight(attackMaterial);
                nodesInRange.Add(n);
            }
            else
            {
                n.GetComponent<Node>().ResetNode();
            }
        }
    }

    public override void Execute(GameObject _gameObject)
    {
        //find out if the game object is a node, or if the gameobject is a character
        if(_gameObject.GetComponent<Adventurer>() == null)
        {
            //Debug.Log("We have a node called: " + _gameObject.name + ". Converting to a character to shoot at");
            target = NodeToTarget(_gameObject);
        }
        else
        {
            //Debug.Log("We have a character called: " + _gameObject.name);
            target = _gameObject;
        }
        if(Vector3.Distance(transform.position, target.transform.position) < range*6)
        {
            Ray ray = new Ray(transform.position, (target.transform.position - transform.position));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == target.gameObject)
                {
                    //Debug.Log("Throwing hooch!");
                    GameObject firedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                    Projectile projectileScript = firedProjectile.GetComponent<Projectile>();
                    projectileScript.Seek(target.transform);
                    GetComponent<Goblin>().ActionsLeft -= 1;
                    return;
                }
            }            
        }

        Debug.Log("What am I shooting at? (Enemy behind obstacle)");
    }
}
