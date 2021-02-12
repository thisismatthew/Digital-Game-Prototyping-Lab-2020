using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AnimationConditions : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public float magnitude;
    Vector3 stationary = new Vector3(0, 0, 0);
    Vector3 currentMovement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        magnitude = agent.velocity.magnitude;
        //setting moving away bool
        if (agent.velocity.x > 0f || agent.velocity.z > 0f)
        {
            animator.SetBool("MovingAway", true);
        }
        else
        {
            animator.SetBool("MovingAway", false);
        }


        //setting movement 
        if (agent.velocity.magnitude != 0.00f)
        {
            animator.SetFloat("Speed", 0.2f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

    }
}
