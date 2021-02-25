using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AnimationConditions : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public float arrivalRadius = 2f;
    public float distanceToDest;
    public bool movingAway = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToDest = Vector3.Distance(transform.position, agent.destination);
        //setting moving away bool
        if ((transform.position.x < agent.destination.x) || (transform.position.z < agent.destination.z))
        {
            movingAway = true;
            animator.SetBool("MovingAway", true);
        }
        else
        {
            movingAway = false;
            animator.SetBool("MovingAway", false);
        }

        //moving left
        if ((transform.position.x > agent.destination.x))
        {
            spriteRenderer.flipX = true;
        }

        //moving right
        if ((transform.position.z > agent.destination.z))
        {
            spriteRenderer.flipX = false;
        }

        //setting movement 
        if(agent.velocity != Vector3.zero || Vector3.Distance(transform.position, agent.destination) > arrivalRadius)
        {
            animator.SetFloat("Speed", 0.2f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}
