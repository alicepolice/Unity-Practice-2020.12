using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
   // public int upper;
    private Stopwatch watch = new Stopwatch();
    private GameObject Test;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        GoTest(1);
        GoTest(1000000);
    }

    void GoTest(int upper)
    {
        print($"本次比较 {upper} 次");
        Test = gameObject;
        watch.Reset(); watch.Start();
        for (int i = 0; i < upper; i++)
        {
            if (Test != null) { }
        }
        watch.Stop(); print($"使用 != 耗时： {watch.Elapsed}");
        watch.Reset(); watch.Start();
        for (int i = 0; i < upper; i++)
        {
            if (ReferenceEquals(Test, null)) { }
        }
        watch.Stop(); print($"使用 ReferenceEquals 耗时： {watch.Elapsed}");
        print("执行结束");
    }
}
