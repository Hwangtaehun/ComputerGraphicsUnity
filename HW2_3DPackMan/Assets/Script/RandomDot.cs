using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDot : MonoBehaviour
{
    public GameObject DotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject dot1 = Instantiate(DotPrefab);
        dot1.transform.position = new Vector3(6.05f, 4.0f, 5.0f);

        for (int i = 0; i < 4; i++)
        {
            float x = Random.Range(-7.5f, 7.5f);
            float z = Random.Range(-1.0f, 5.0f);
            GameObject dot = Instantiate(DotPrefab);
            dot.transform.position = new Vector3(x, 2.0f, z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
