using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimeTest2 : MonoBehaviour
{
   // public int upper;
    private Stopwatch watch = new Stopwatch();
    private GameObject Test;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        GoTest(1);
        GoTest(1000000);
        GoTest(10000000);
        GoTest(100000000);
        GoTest(1000000000);
    }

    void GoTest(int upper)
    {
        print($"本次比较 {upper} 次");
        int k = 0;
        watch.Reset(); watch.Start();
        for (int i = 0; i < upper; i++)
        {
            if (k>1) { }
        }
        watch.Stop(); print($"> 耗时： {watch.Elapsed}");
        watch.Reset(); watch.Start();
        for (int i = 0; i < upper; i++)
        {
            if (k >= 1) { }
        }
        watch.Stop(); print($">= 耗时： {watch.Elapsed}");
    }
}
