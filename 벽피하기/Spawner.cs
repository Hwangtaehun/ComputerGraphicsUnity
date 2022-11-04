using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public float interval;
    public float range = 5.0f;

    void Start()
    {
        StartCoroutine(CreateWall());
    }

   IEnumerator CreateWall()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);
        while(true)
        {
            float wallPosY = Random.Range(-range, range);
            transform.position = new Vector3(transform.position.x, wallPosY, transform.position.z);
            Instantiate(wallPrefab, transform.position, transform.rotation);
            yield return wait;
        }
    }
}
