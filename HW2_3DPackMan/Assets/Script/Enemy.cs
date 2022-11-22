using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    Animator animator;
    bool runaway = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(runaway == false)
        {
            agent.destination = target.transform.position; // 쫓아갈 위치 설정
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        else
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            Vector3 dirToTarget = transform.position - target.transform.position;
            Vector3 newPos = transform.position + dirToTarget;
            agent.SetDestination(newPos);
        }
    }

    public void RunTure()
    {
        runaway = true;
    }
}
