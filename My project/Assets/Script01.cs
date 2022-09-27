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
} // 따로 생성자 소멸자를 따로 만들 필요가 없다.

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


        //string str = "반복";

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

        string txt = "출력 성공";
        return txt;
    }
}
