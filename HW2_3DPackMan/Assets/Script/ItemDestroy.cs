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
        else if (other.tag == "ScoreAdd")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "PlayerStop")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "PlayerSpeed")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "EnemyStop")
        {
            Destroy(gameObject);
        }
    }
}
