using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    Animator animator; 
    Collider EnemyCd;
    bool runaway = false;
    bool stop = false;
    bool destory = false;
    float enemySpeed = 3.5f;
    //float enemyTime = 0.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        EnemyCd = GetComponent<Collider>();
        agent.speed = enemySpeed;
    }

    void Update()
    {
        //enemyTime += Time.deltaTime;
        if (stop == true)
        {
            enemySpeed = 0.0f;
            agent.speed = enemySpeed;
            animator.SetFloat("Speed", agent.velocity.magnitude);
            Invoke("Go", 5.0f);
            //if(enemyTime > 5.0f)
            //{
            //    Debug.Log(enemyTime);
            //    enemyTime = 0.0f;
            //    Go();
            //}
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

        if(destory == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            EnemyCd.enabled = false;
        }

        if(transform.position.x <= -9.0 && transform.position.z >= 6.5)
        {
            Turn();
        }
        else if (transform.position.x <= -9.0 && transform.position.z <= -2.5)
        {
            Turn();
        }
        else if (transform.position.x >= 9.0 && transform.position.z >= 6.5)
        {
            Turn();
        }
        else if (transform.position.x >= 9.0 && transform.position.z <= -2.5)
        {
            Turn();
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

    public void Recover()
    {
        runaway = false;
    }

    public void Stop()
    {
        stop = true;
    }

    public void Destory()
    {
        destory = true;
    }

    private void Go()
    {
        stop = false;
        enemySpeed = 3.5f;
        agent.speed = enemySpeed;
    }

    private void Turn()
    {
        agent.destination = new Vector3(0, 0, 0);
        Invoke("RunAway", 2.0f);
    }
}
