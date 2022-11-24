using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject prefabWallCube;
    public float interval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateCube());
    }

    // Update is called once per frame
    IEnumerator CreateCube()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);
        while (true)
        {
            int dice = Random.Range(1, 21);
            switch(dice)
            {
                case 1:
                    transform.position = new Vector3(0.0f, 2.0f, 2.0f);
                    break;
                case 2:
                    transform.position = new Vector3(-1.5f, 2.0f, 0.5f);
                    break;
                case 3:
                    transform.position = new Vector3(0.0f, 2.0f, 0.5f);
                    break;
                case 4:
                    transform.position = new Vector3(0.0f, 2.0f, 3.5f);
                    break;
                case 5:
                    transform.position = new Vector3(1.5f, 2.0f, 2.0f);
                    break;
                case 6:
                    transform.position = new Vector3(3.0f, 2.0f, 2.0f);
                    break;
                case 7:
                    transform.position = new Vector3(-3.0f, 2.0f, 0.5f);
                    break;
                case 8:
                    transform.position = new Vector3(-3.0f, 2.0f, -1.0f);
                    break;
                case 9:
                    transform.position = new Vector3(-3.0f, 2.0f, 2.0f);
                    break;
                case 10:
                    transform.position = new Vector3(-3.0f, 2.0f, 3.5f);
                    break;
                case 11:
                    transform.position = new Vector3(3.0f, 2.0f, 0.5f);
                    break;
                case 12:
                    transform.position = new Vector3(3.0f, 2.0f, -1.0f);
                    break;
                case 13:
                    transform.position = new Vector3(3.0f, 2.0f, 3.5f);
                    break;
                case 14:
                    transform.position = new Vector3(4.5f, 2.0f, 3.5f);
                    break;
                case 15:
                    transform.position = new Vector3(6.0f, 2.0f, 3.5f);
                    break;
                case 16:
                    transform.position = new Vector3(4.5f, 2.0f, 5.0f);
                    break;
                case 17:
                    transform.position = new Vector3(-4.5f, 2.0f, 3.5f);
                    break;
                case 18:
                    transform.position = new Vector3(-6.0f, 2.0f, 3.5f);
                    break;
                case 19:
                    transform.position = new Vector3(-6.0f, 2.0f, 5.0f);
                    break;
                case 20:
                    transform.position = new Vector3(-6.0f, 2.0f, 2.0f);
                    break;
                case 21:
                    transform.position = new Vector3(-6.0f, 2.0f, 0.5f);
                    break;
            }
            Instantiate(prefabWallCube, transform.position, transform.rotation);
            yield return wait;
        }
    }
}
