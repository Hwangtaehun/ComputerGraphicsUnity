using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
    public string name;
    public int year;

    public void PrintCarName()
    {
        Debug.Log(name);
    }

    public void PrintCarYear()
    {
        Debug.Log(year);
    }
} // ���� ������ �Ҹ��ڸ� ���� ���� �ʿ䰡 ����.

public class Script01 : MonoBehaviour
{
    // Start is called before the first frame update
    //public int maxCount = 0;

    void Start()
    {

        Car myCar = new Car();

        myCar.name = "BMW";
        myCar.year = 2020;


        myCar.PrintCarName();
        myCar.PrintCarYear();

       //string txt = myStart(100, 50, 80, 90, 95);
       // Debug.Log(txt);


        //string str = "�ݺ�";

        //int count = 0;

        //do
        //{
        //    Debug.Log(str + count);
        //    count++;
        //} while (count < 5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string myStart(int a, int b, int c, int d, int e)
    {
        int[] score = { 100, 50, 80, 90, 95 };
        score[0] = a;


        foreach (int num in score)
        {
            Debug.Log(num);
        }

        string txt = "��� ����";
        return txt;
    }
}
