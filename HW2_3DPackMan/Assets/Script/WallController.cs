using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    Collider WallCube;
    MeshRenderer WallRd;
    float currentPosition;
    public float moveSpeed = 10.0f;

    void Start()
    {
        WallRd = GetComponent<MeshRenderer>();
        WallCube = GetComponent<Collider>();
        WallCube.isTrigger = true;
        WallRd.enabled = false;
        currentPosition = transform.position.y;
        Destroy(gameObject, 10);
    }

    void Update()
    {
        currentPosition -= Time.deltaTime * moveSpeed;
        transform.position = new Vector3(transform.position.x, currentPosition, transform.position.z);

        if (transform.position.y<= 0.1f)
        {
            WallCube.isTrigger = false;
            WallRd.enabled = true;
            moveSpeed = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //WallCube.isTrigger = true;
            Destroy(gameObject);
        }
    }
}
