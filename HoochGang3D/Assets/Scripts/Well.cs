using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    private TurnManager tm;

    private void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
    }

    private void Update()
    {
        if (tm.gameObject.GetComponent<GameManager>().gameIsOver)
        {
            return;
        }

        CheckAdj();
    }

    private void CheckAdj()
    {
        if (tm.adventurers.Count <= 0)
        {
            return;
        }

        foreach (GameObject a in tm.adventurers)
        {
            if (a == null)
            {
                return;
            }

            float dist = Vector3.Distance(transform.position, a.transform.position);

            if (dist <= 7.5f) //immediately adjacent to the well
            {
                Destroy(this.gameObject);
            }
        }
    }
}
