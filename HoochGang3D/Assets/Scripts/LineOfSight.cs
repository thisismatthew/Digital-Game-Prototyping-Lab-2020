using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    //private GameManager gm;

    private void Start()
    {
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                this.gameObject.GetComponent<Movement>().SetDest(hit.collider.gameObject.GetComponent<Movement>().agent.destination);
                if (Vector3.Distance(transform.position, gameObject.GetComponent<Movement>().agent.destination) < 3f)
                {
                    Destroy(hit.collider.gameObject);
                    return;
                }
            }
        }
    }
}
