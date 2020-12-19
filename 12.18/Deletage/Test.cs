using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public delegate string Del(string str);

    public delegate void Del2(int i);

    public delegate int Del3(int a, int b);

    public delegate bool Del4(bool isB);
    void Start()
    {
        #region 简单委托
        //string aaa = Go(ToUpper, "helloworld");
        //print(aaa);
        //Del2 del = PrintDigit;
        //del(2);
        #endregion

        #region 匿名方法，关键字、参数类型、方法体
        //int a = Test1(Subtraction, 2, 1);
        //print(a);
        //int b = Test1(delegate(int c, int d) { return c - d; },2,1);
        //print(b);
        //bool isB = ReturnBool(delegate(bool isA) { return isA; },true);
        //print(isB);
        //Del4 del = delegate(bool test) { print("Helloworld");return test; };
        //print(del(true));
        #endregion

    }

    private bool ReturnBool(Del4 del,bool isA)
    {
        return del(isA);
    }

    private int Subtraction(int a, int b)
    {
        return a - b;
    }

    private int Test1(Del3 del, int a,int b)
    {
        return del(a, b);
    }

    private string ToUpper(string i)
    {
        return i.ToUpper();
    }

    private void PrintDigit(int i)
    {
        print(i);
    }

    public static string Go(Del hello,String item)
    {
        return hello(item);
    }
}
