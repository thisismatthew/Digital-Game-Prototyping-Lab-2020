using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Attack
{
    protected override void DisplayRange()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, range * 5);

        for (int i = 0; i < hits.Length; i++)
        {
            if (!hits[i].collider.gameObject.CompareTag("Node")){
                  continue;
            }
        }
    }

    protected override void Execute()
    {
        //instantiate arrow/bottle/projectile
        //set target to enemy
    }
}
