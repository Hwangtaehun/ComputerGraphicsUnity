using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMove : MonoBehaviour
{
    private float currentPosition;
    public float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition -= Time.deltaTime * moveSpeed;
        transform.position = new Vector3(transform.position.x, transform.position.y, currentPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DeadZone")
        {
            Destroy(gameObject);
        }
    }
}
