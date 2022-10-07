using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSideController : MonoBehaviour
{
    private float currentPosition;
    public float minX = 12.7f;
    public float maxX = 21.15f;

    [Range(1, 100)]
    public float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += Time.deltaTime * moveSpeed;
        if(currentPosition >= maxX)
        {
            moveSpeed *= -1;
            currentPosition = maxX;
        }
        else if(currentPosition <= minX)
        {
            moveSpeed *= -1;
            currentPosition = minX;
        }
        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
    }
}
