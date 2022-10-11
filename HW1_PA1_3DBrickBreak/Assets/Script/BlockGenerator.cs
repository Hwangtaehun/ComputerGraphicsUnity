using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject blockPrefab;
    private int blockCnt = 0;
    private float timeCount = 0.0f;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject block = Instantiate(blockPrefab);
            int px = Random.Range(13, 21);
            int pz = Random.Range(93, 95);
            block.transform.position = new Vector3(px, -4.3f, pz);
            blockCnt++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float px = Random.Range(13.0f, 21.0f);
        float pz = Random.Range(93.0f, 95.0f);
        Vector3 randomPos = new Vector3(px, -4.3f, pz);

        if (blockCnt <= 25)
        {
            if (timeCount > 2.0f)
            {
                GameObject block = Instantiate(blockPrefab, randomPos, transform.rotation);
                timeCount = 0.0f;
                blockCnt++;
            }
        }
        timeCount += Time.deltaTime;
    }
}
