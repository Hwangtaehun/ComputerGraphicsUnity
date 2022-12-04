using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public GameObject prefabScoreAdd;
    public GameObject prefabPlayerstop;
    public GameObject prefabEnemystop;
    public GameObject prefabPlayerspeed;
    public float interval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateItem());
    }

    // Update is called once per frame
    IEnumerator CreateItem()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);
        while(true)
        {
            int dice = Random.Range(1, 12);
            float x = Random.Range(-6.0f, 6.0f);
            float z = Random.Range(4.0f, -1.45f);
            transform.position = new Vector3(x, 0.45f, z);
            if (dice <= 3)
            {
                Instantiate(prefabScoreAdd, transform.position, transform.rotation);
            }
            else if (dice > 3 && dice <= 6)
            {
                Instantiate(prefabPlayerstop, transform.position, transform.rotation);
            }
            else if (dice > 6 && dice <= 9)
            {
                Instantiate(prefabEnemystop, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(prefabPlayerspeed, transform.position, transform.rotation);
            }
            yield return wait;
            //Instantiate(prefabEnemystop, transform.position, transform.rotation);
            //yield return wait;
        }
    }
}

//int location = Random.Range(1, 21);
//switch (location)
//{
//    case 1:
//        transform.position = new Vector3(0.0f, 0.45f, 2.0f);
//        break;
//    case 2:
//        transform.position = new Vector3(-1.5f, 0.45f, 0.5f);
//        break;
//    case 3:
//        transform.position = new Vector3(0.0f, 0.45f, 0.5f);
//        break;
//    case 4:
//        transform.position = new Vector3(0.0f, 0.45f, 3.5f);
//        break;
//    case 5:
//        transform.position = new Vector3(1.5f, 0.45f, 2.0f);
//        break;
//    case 6:
//        transform.position = new Vector3(3.0f, 0.45f, 2.0f);
//        break;
//    case 7:
//        transform.position = new Vector3(-3.0f, 0.45f, 0.5f);
//        break;
//    case 8:
//        transform.position = new Vector3(-3.0f, 0.45f, -1.0f);
//        break;
//    case 9:
//        transform.position = new Vector3(-3.0f, 0.45f, 2.0f);
//        break;
//    case 10:
//        transform.position = new Vector3(-3.0f, 0.45f, 3.5f);
//        break;
//    case 11:
//        transform.position = new Vector3(3.0f, 0.45f, 0.5f);
//        break;
//    case 12:
//        transform.position = new Vector3(3.0f, 0.45f, -1.0f);
//        break;
//    case 13:
//        transform.position = new Vector3(3.0f, 0.45f, 3.5f);
//        break;
//    case 14:
//        transform.position = new Vector3(4.5f, 0.45f, 3.5f);
//        break;
//    case 15:
//        transform.position = new Vector3(6.0f, 0.45f, 3.5f);
//        break;
//    case 16:
//        transform.position = new Vector3(4.5f, 0.45f, 5.0f);
//        break;
//    case 17:
//        transform.position = new Vector3(-4.5f, 0.45f, 3.5f);
//        break;
//    case 18:
//        transform.position = new Vector3(-6.0f, 0.45f, 3.5f);
//        break;
//    case 19:
//        transform.position = new Vector3(-6.0f, 0.45f, 5.0f);
//        break;
//    case 20:
//        transform.position = new Vector3(-6.0f, 0.45f, 2.0f);
//        break;
//    case 21:
//        transform.position = new Vector3(-6.0f, 0.45f, 0.5f);
//        break;
//}
