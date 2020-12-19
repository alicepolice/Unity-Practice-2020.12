using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Generics2 : MonoBehaviour
{
    delegate bool Del<T>(T a, T b);
    private void Start()
    {
        #region 调用泛型数字交换
        //int a = 1;
        //int b = 2;
        //Change<int>(ref a,ref b);
        //print(a);

        #endregion

        #region 调用排序

        //int[] a = new int[] {5,4,1,7,5,61};
        //Sort(ref a);
        //foreach (int i in a)
        //{
        //    print(i);
        //}

        #endregion

        #region 调用泛型排序

        int[] test = new[] {7, 8, 1, 2, 4, 6, 7};
        Sort((a,b)=>
        {
            return a > b;
        },ref test);
        foreach (int i in test)
        {
            print(i);
        }

        #endregion
    }

    private void Sort(ref int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        { 
            for (int j = 0; j < nums.Length-1-i; j++)
            {
                if (nums[j]>nums[j+1])
                {
                    int temp = nums[j];
                    nums[j] = nums[j + 1];
                    nums[j + 1] = temp;
                }
            }
        }
    }

    private void Sort<T>(Del<T> del,ref T[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length - 1 - i; j++)
            {
                if (del(nums[j],nums[j + 1]))
                {
                    T temp = nums[j];
                    nums[j] = nums[j + 1];
                    nums[j + 1] = temp;
                }
            }
        }
    }

    private void Change(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    private void Change<T>(ref T a, ref T b) where T : struct
    {
        T temp = a;
        a = b;
        b = temp;
    }
}
