using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class GenericsTool
{
    /// <summary>
    /// 同类对象进行筛选，比如多个敌人Enemy中筛选 血量大于50的敌人
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="del"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public static T[] FindInAll<T>(Func<T,bool> del, T[] items)
    {
        List<T> buffer = new List<T>();
        for (int i = 0; i < items.Length; i++)
        {
            if (del(items[i]))
            {
                buffer.Add(items[i]);
            }
        }
        return buffer.ToArray();
    }

    public static T FindMax<T, Q>(Func<T, Q> del, T[] items) where Q:IComparable
    {
        T max = items[0];
        for (int i = 1; i < items.Length; i++)
        {
            if (del(max).CompareTo(del(items[i])) < 0)
            {
                max = items[i];
            }
        }
        return max;
    }

    public static T FindMin<T, Q>(Func<T, Q> del, T[] items) where Q : IComparable
    {
        T min = items[0];
        for (int i = 1; i < items.Length; i++)
        {
            if (del(min).CompareTo(del(items[i]))>0)
            {
                min = items[i];
            }
        }
        return min;
    }

    public static T[] SortDesc<T, Q>(Func<T, Q> del, T[] items,out int count) where Q:IComparable
    {
        count = 0;
        for (int i = 0; i < items.Length; i++) // 循环次数
        {
            for (int j = 0; j < items.Length-1-i;j++)  // 进行比较
            {
                if (del(items[j]).CompareTo(del(items[j+1]))<0)
                {
                    T temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                    count++;
                }
            }
        }
        return items;
    }

    public static T[] NewSortDesc<T, Q>(Func<T, Q> del, T[] items,out int count) where Q : IComparable
    {
        int f = 0;
        count = 0;
        for (int i = 0; i < items.Length; i++) // 循环次数
        {
            for (int j = 0; j < items.Length - 1 - i; j++)  // 进行比较
            {
                if (del(items[j]).CompareTo(del(items[j + 1])) < 0)
                {
                    T temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                    f++;
                    count++;
                }
                if (f == 0) return items;
            }
            f = 0;
        }
        return items;
    }
}
