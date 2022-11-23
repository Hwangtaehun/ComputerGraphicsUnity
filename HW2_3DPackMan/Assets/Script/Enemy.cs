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
    bool stop = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (stop == true)
        {
            agent.destination = transform.position;
            if (runaway == true)
                Invoke("RunAway", 5.0f);
            else
                Invoke("Chase", 5.0f);
        }
        else
        {
            if (runaway == false)
            {
                Chase();
            }
            else
            {
                RunAway();
            }
        }
    }

    private void Chase()
    {
        agent.destination = target.transform.position; // 쫓아갈 위치 설정
        animator.SetFloat("Speed", agent.velocity.magnitude);
        if (stop == true)
            stop = false;
    }

    private void RunAway()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        Vector3 dirToTarget = transform.position - target.transform.position;
        Vector3 newPos = transform.position + dirToTarget;
        agent.SetDestination(newPos);
        if (stop == true)
            stop = false;
    }

    public void RunTure()
    {
        runaway = true;
    }

    public void Stop()
    {
        stop = true;
    }
}
