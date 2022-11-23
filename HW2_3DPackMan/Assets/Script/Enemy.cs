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
    float enemyTime = 0.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        enemyTime += Time.deltaTime;
        if (stop == true)
        {
            agent.speed = 0f;
            animator.SetFloat("Speed", agent.velocity.magnitude);
            if(enemyTime > 5.0f)
            {
                Debug.Log(enemyTime);
                enemyTime = 0.0f;
                Go();
            }
        }
        else if(stop == false)
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
    }

    private void RunAway()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        Vector3 dirToTarget = transform.position - target.transform.position;
        Vector3 newPos = transform.position + dirToTarget;
        agent.SetDestination(newPos);
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void RunTure()
    {
        runaway = true;
    }

    public void Stop()
    {
        stop = true;
    }

    private void Go()
    {
        stop = false;
        agent.speed = 3.5f;
    }
}
