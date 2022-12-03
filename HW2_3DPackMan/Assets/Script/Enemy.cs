using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Collider EnemyCd;
    private bool runaway = false;
    private bool destory = false;
    private float enemySpeed = 3.5f;

    public GameObject target;
    public GameObject Enemyname;
    //public Color Enemycolor;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        EnemyCd = GetComponent<Collider>();
        agent.speed = enemySpeed;
        //MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        //for (int i = 0; i < renderers.Length; i++)
        //    renderers[i].material.color = Enemycolor;
    }

    void Update()
    {
        if (runaway == false)
        {
            Chase();
        }
        else
        {
            RunAway();
        }

        if (destory == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            EnemyCd.enabled = false;
            Enemyname.SetActive(false);
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
        agent.isStopped = true;
        agent.speed = 0.0f;
        Invoke("Go", 5.0f);
    }

    public void Destory()
    {
        destory = true;
    }

    private void Go()
    {
        agent.speed = enemySpeed;
        agent.isStopped = false;
        //agent.enabled = true;
    }

    private void Turn()
    {
        agent.destination = new Vector3(0, 0, 0);
        Invoke("RunAway", 2.0f);
    }
}

//private bool stop = false;
//enemyTime += Time.deltaTime;
//if (stop == true)
//{
//    agent.enabled = false;
//    agent.speed = 0.0f;
//    animator.SetFloat("Speed", agent.velocity.magnitude);
//    Invoke("Go", 5.0f);
//    //if(enemyTime > 5.0f)
//    //{
//    //    Debug.Log(enemyTime);
//    //    enemyTime = 0.0f;
//    //    Go();
//    //}
//}
//else if(stop == false)
//{
//    if (runaway == false)
//    {
//        Chase();
//    }
//    else
//    {
//        RunAway();
//    }
//}