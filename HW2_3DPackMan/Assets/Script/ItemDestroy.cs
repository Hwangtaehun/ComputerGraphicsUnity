using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private float currentPosition;
 
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Maze")
        {
            Destroy(gameObject);
        }
    }
}
