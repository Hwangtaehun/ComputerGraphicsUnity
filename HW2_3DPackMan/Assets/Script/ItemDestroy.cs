using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private MeshRenderer itemRd;
    private float currentPosition;
    public float moveSpeed = 10.0f;

    void Start()
    {
        Destroy(gameObject, 5.0f);
        itemRd = GetComponent<MeshRenderer>();
        itemRd.enabled = false;
        currentPosition = transform.position.y;
    }
    void Update()
    {
        currentPosition -= Time.deltaTime * moveSpeed;
        transform.position = new Vector3(transform.position.x, currentPosition, transform.position.z);

        if (transform.position.y <= 0.5f)
        {
            moveSpeed = 0.0f;
            itemRd.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Maze")
        {
            Destroy(gameObject);
        }
    }
}
