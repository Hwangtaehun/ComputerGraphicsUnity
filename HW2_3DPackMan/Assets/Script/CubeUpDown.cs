using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeUpDown : MonoBehaviour
{
    private float currentPosition;
    public float minY = -2.0f;
    public float maxY = 2.0f;

    [Range(1, 10)]
    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += Time.deltaTime * moveSpeed;
        if (currentPosition >= maxY)
        {
            moveSpeed *= -1;
            currentPosition = maxY;
        }
        else if (currentPosition <= minY)
        {
            moveSpeed *= -1;
            currentPosition = minY;
        }
        transform.position = new Vector3(transform.position.x, currentPosition, transform.position.z);
    }

    void moveStop()
    {
        moveSpeed = 0.0f;
    }
}
