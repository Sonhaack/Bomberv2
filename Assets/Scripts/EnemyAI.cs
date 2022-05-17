using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    
    public float detectDistance = 5f;
    private float playerDistance;
    // components
    private NavMeshAgent agent;
    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.transform.position);

        // Disable when dead
        if (!animator.GetBool("isDead"))
        {
            
            if (playerDistance < detectDistance)
            {
                agent.SetDestination(player.transform.position);
            }
            
            
            // Animations
            if (rb.IsSleeping())
            {
                animator.SetBool("isRunning", false);
                return;
            }
            animator.SetBool("isRunning", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Col :" + other.name);
        if (other.CompareTag("Player"))
        {
            if (!animator.GetBool("isDead"))
            {
                other.GetComponentInChildren<Animator>().SetBool("isDead", true);    
            }
        }
    }
}

