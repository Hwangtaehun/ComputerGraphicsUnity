using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveZ : MonoBehaviour
{
    private float currentPosition;
    public float minZ = 0.5f;
    public float maxZ = 3.5f;

    [Range(1, 10)]
    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += Time.deltaTime * moveSpeed;
        if (currentPosition >= maxZ)
        {
            moveSpeed *= -1;
            currentPosition = maxZ;
        }
        else if (currentPosition <= minZ)
        {
            moveSpeed *= -1;
            currentPosition = minZ;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, currentPosition);
    }

    void moveStop()
    {
        moveSpeed = 0.0f;
    }
}
