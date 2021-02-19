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
                //node.Highlight(attackMaterial);
                node.SpriteHighlight(attackColor);
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
        base.Execute();

        //find out if the game object is a node, or if the gameobject is a character
        if(!_gameObject.CompareTag("Adventurer"))
        {
            target = NodeToTarget(_gameObject);
            if (target == null)
            {
                return;
            }
        }
        else
        {
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
