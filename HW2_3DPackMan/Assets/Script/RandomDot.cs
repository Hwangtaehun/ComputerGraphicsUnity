using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDot : MonoBehaviour
{
    private List<int> numberList = new List<int>();

    public GameObject DotPrefab;
    public int dotcount = 4;
    // Start is called before the first frame update
    void Start()
    {
        GameObject dot1 = Instantiate(DotPrefab);
        dot1.transform.position = new Vector3(6.05f, 4.0f, 5.0f);

        CreateRandom(1, 25);

        for (int i = 0; i < dotcount; i++)
        {

            int location = numberList[i];
            switch (location)
            {
                case 1:
                    transform.position = new Vector3(-4.5f, 2.0f, 2.0f);
                    break;
                case 2:
                    transform.position = new Vector3(-4.5f, 2.0f, 0.5f);
                    break;
                case 3:
                    transform.position = new Vector3(-5.96f, 2.0f, -1.0f);
                    break;
                case 4:
                    transform.position = new Vector3(-4.5f, 2.0f, -1.0f);
                    break;
                case 5:
                    transform.position = new Vector3(-4.5f, 2.0f, 5.0f);
                    break;
                case 6:
                    transform.position = new Vector3(-3.0f, 2.0f, 5.0f);
                    break;
                case 7:
                    transform.position = new Vector3(-1.5f, 2.0f, 5.0f);
                    break;
                case 8:
                    transform.position = new Vector3(0.0f, 2.0f, 5.0f);
                    break;
                case 9:
                    transform.position = new Vector3(1.5f, 2.0f, 5.0f);
                    break;
                case 10:
                    transform.position = new Vector3(-1.5f, 2.0f, 3.5f);
                    break;
                case 11:
                    transform.position = new Vector3(-1.5f, 2.0f, -1.0f);
                    break;
                case 12:
                    transform.position = new Vector3(0.0f, 2.0f, -1.0f);
                    break;
                case 13:
                    transform.position = new Vector3(-1.5f, 2.0f, 2.0f);
                    break;
                case 14:
                    transform.position = new Vector3(1.5f, 2.0f, -1.0f);
                    break;
                case 15:
                    transform.position = new Vector3(1.5f, 2.0f, 0.5f);
                    break;
                case 17:
                    transform.position = new Vector3(4.5f, 2.0f, -1.0f);
                    break;
                case 18:
                    transform.position = new Vector3(4.5f, 2.0f, 0.5f);
                    break;
                case 20:
                    transform.position = new Vector3(4.5f, 2.0f, 2.0f);
                    break;
                case 21:
                    transform.position = new Vector3(3.0f, 2.0f, 5.0f);
                    break;
                case 22:
                    transform.position = new Vector3(6.0f, 2.0f, 2.0f);
                    break;
                case 23:
                    transform.position = new Vector3(1.5f, 2.0f, 3.5f);
                    break;
                case 25:
                    transform.position = new Vector3(6.0f, 2.0f, -1.0f);
                    break;
            }
            Instantiate(DotPrefab, transform.position, transform.rotation);
            //float x = Random.Range(-7.5f, 7.5f);
            //float z = Random.Range(-1.0f, 5.0f);
            //GameObject dot = Instantiate(DotPrefab);
            //dot.transform.position = new Vector3(x, 2.0f, z);
        }
    }

   void CreateRandom(int min, int max)
    {
        int currentNumber = Random.Range(min, max);

        for(int i = 0; i < dotcount;)
        {
            if(numberList.Contains(currentNumber))
            {
                currentNumber = Random.Range(min, max);
            }
            else
            {
                numberList.Add(currentNumber);
                i++;
            }
        }
    }
}
