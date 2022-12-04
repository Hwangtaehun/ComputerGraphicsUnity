using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private MeshRenderer itemRd;

    void Start()
    {
        Destroy(gameObject, 5.0f);
        itemRd = GetComponent<MeshRenderer>();
        itemRd.enabled = false;
        Invoke("showItem", 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Maze")
        {
            Destroy(gameObject);
        }
    }

    private void showItem()
    {
        itemRd.enabled = true;
    }
}

//private void OnTriggerEnter(Collider other)
//{
//    if (other.tag == "Maze")
//    {
//        Destroy(gameObject);
//    }
//}

//private void OnCollisionEnter(Collision collision)
//{
//    if (collision.gameObject.CompareTag("Maze"))
//    {
//        Destroy(gameObject);
//    }
//}

//private Collider itemCd;
//itemCd = GetComponent<Collider>();
//itemCd.isTrigger = false;
//itemCd.isTrigger = true;

//private float currentPosition;

//public float moveSpeed = 10.0f;
//currentPosition = transform.position.y;
//void Update()
//{
//    //currentPosition -= Time.deltaTime * moveSpeed;
//    //transform.position = new Vector3(transform.position.x, currentPosition, transform.position.z);

//    //if (transform.position.y <= 0.5f)
//    //{
//    //    moveSpeed = 0.0f;
//    //    itemRd.enabled = true;
//    //}
//}