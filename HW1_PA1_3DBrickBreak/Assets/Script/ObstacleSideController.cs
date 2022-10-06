using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSideController : MonoBehaviour
{
    private int sign = -1;
    public float minX, maxX;

    [Range(1, 100)]
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        minX = 12.72f;
        maxX = 21.17f;
        moveSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 0.0f)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);

            if(transform.position.x <= minX || transform.position.x >= maxX)
            {
                sign *= -1;
            }
        }
    }
}
