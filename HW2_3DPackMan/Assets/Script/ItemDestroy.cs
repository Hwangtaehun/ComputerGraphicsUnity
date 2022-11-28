using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private Collider itemCube;
    private MeshRenderer itemRd;
    private float currentPosition;
    public float moveSpeed = 10.0f;

    void Start()
    {
        //Destroy(gameObject, 5.0f);
        //itemRd = GetComponent<MeshRenderer>();
        //itemCube = GetComponent<Collider>();
        //itemCube.isTrigger = false;
        //itemRd.enabled = false;
        currentPosition = transform.position.y;
    }
    void Update()
    {
        currentPosition -= Time.deltaTime * moveSpeed;
        transform.position = new Vector3(transform.position.x, currentPosition, transform.position.z);

        if (transform.position.y <= 0.5f)
        {
            moveSpeed = 0.0f;
            //itemCube.isTrigger = true;
            //itemRd.enabled = true;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Maze"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Maze")
        {
            Destroy(gameObject);
        }
        //else if (other.tag == "ScoreAdd")
        //{
        //    Destroy(gameObject);
        //}
        //else if (other.tag == "PlayerStop")
        //{
        //    Destroy(gameObject);
        //}
        //else if (other.tag == "PlayerSpeed")
        //{
        //    Destroy(gameObject);
        //}
        //else if (other.tag == "EnemyStop")
        //{
        //    Destroy(gameObject);
        //}
    }
}
