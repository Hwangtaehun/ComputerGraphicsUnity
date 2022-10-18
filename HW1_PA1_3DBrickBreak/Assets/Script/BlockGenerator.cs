using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject doubleblockPrefab;
    public GameObject wallblockPrefab;
    private int blockCnt = 0;
    private float timeCount = 0.0f;
    private float timeWall = 0.0f;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            float px = Random.Range(13.0f, 21.0f);
            float pz = Random.Range(93.0f, 95.0f);

            if (i<3)
            {
                GameObject block = Instantiate(doubleblockPrefab);
                block.transform.position = new Vector3(px, -4.3f, pz);
            }
            else
            {
                GameObject block = Instantiate(blockPrefab);
                block.transform.position = new Vector3(px, -4.3f, pz);
            }
            
            blockCnt++;
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().UpdateBlockCnt(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float px = Random.Range(13.0f, 21.0f);
        float pz = Random.Range(93.0f, 95.0f);
        int dice = Random.Range(1, 9);
        Vector3 randomPos = new Vector3(px, -4.3f, pz);
        int doubleblock = 8;
        GameObject manager = GameObject.Find("GameManager");
        
        if(timeWall > 10.0f)
        {
            for(int i = 0; i < 2; i++)
            {
                float ppx = Random.Range(13.0f, 21.0f);
                GameObject block = Instantiate(wallblockPrefab);
                block.transform.position = new Vector3(ppx, -4.3f, 92.0f);
                Destroy(block, 5.0f);
            }
            timeWall = 0.0f;
        }

        if (blockCnt < 15)
        {
            if (timeCount > 2.0f)
            {
                if(dice >= doubleblock)
                {
                    Instantiate(doubleblockPrefab, randomPos, transform.rotation);
                }
                else
                {
                    Instantiate(blockPrefab, randomPos, transform.rotation);
                }
                blockCnt++;
                manager.GetComponent<GameManager>().UpdateBlockCnt(1);
                timeCount = 0.0f;
            }
        }
        timeCount += Time.deltaTime;
        timeWall += Time.deltaTime;
    }
}
