using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [HideInInspector]public string enemyTag;
    [SerializeField]private float range;
    public Material lineOfSightMaterial;

    private void Start()
    {
        if (gameObject.CompareTag("Goblin"))
        {
            enemyTag = "Adventurer";
        }
        else
        {
            enemyTag = "Goblin";
        }
    }

    private void Update()
    {
        if (GetComponent<Movement>().agent.velocity != Vector3.zero) //only show line of sight when not moving
        {
            GameObject.Find("GameManager").GetComponent<NodeManager>().ResetAllNodes();
            return;
        }

        CheckHit();
    }

    private Collider[] GetCollisions()
    {
        Collider[] result = Physics.OverlapSphere(transform.position, range*5);
        return result;
    }

    private void CheckHit()
    {
        Vector3 charToColl;
        float dot;

        foreach (Collider c in GetCollisions())
        {
            charToColl = (c.transform.position - transform.position).normalized; //get the distance between the collider and the character
            dot = Vector3.Dot(charToColl, transform.forward); //convert it to a float
            if (dot >= Mathf.Cos(45) && c.CompareTag("Detector"))
            {
                c.gameObject.GetComponentInParent<Node>().Highlight(lineOfSightMaterial);
            }
            dot = Vector3.Dot(charToColl, -transform.forward);
            if (dot >= Mathf.Cos(45) && c.CompareTag("Detector"))
            {
                c.gameObject.GetComponentInParent<Node>().Highlight(lineOfSightMaterial);
            }
            dot = Vector3.Dot(charToColl, transform.right);
            if (dot >= Mathf.Cos(45) && c.CompareTag("Detector"))
            {
                c.gameObject.GetComponentInParent<Node>().Highlight(lineOfSightMaterial);
            }
            dot = Vector3.Dot(charToColl, -transform.right);
            if (dot >= Mathf.Cos(45) && c.CompareTag("Detector"))
            {
                c.gameObject.GetComponentInParent<Node>().Highlight(lineOfSightMaterial);
            }
        }
    }

    public List<GameObject> GetTargetsInRange()
    {
        List<GameObject> result = new List<GameObject>();

        //add those with our enemytag to the result
        /*foreach (Collider c in GetCollisions())
        {
            if(c.CompareTag(enemyTag))
            {
                result.Add(c.gameObject);
            }
        }*/

        Vector3 charToColl;
        float dot;

        foreach (Collider c in GetCollisions())
        {
            charToColl = (c.transform.position - transform.position).normalized; //get the distance between the collider and the character
            dot = Vector3.Dot(charToColl, transform.forward); //convert it to a float
            if (dot >= Mathf.Cos(45) && c.CompareTag(enemyTag))
            {
                result.Add(c.gameObject);
            }
        }

        return result; 
    }
}
