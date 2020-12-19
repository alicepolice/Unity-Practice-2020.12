using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTool : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("获取血量大于50的敌人"))
        {
            Enemy[] all = FindObjectsOfType<Enemy>();
            Enemy[] result = GenericsTool.FindInAll((e) => e.hp > 50, all);

            for (int i = 0; i < result.Length; i++)
            {
                result[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }

        }
        if (GUILayout.Button("获取最大血量的敌人"))
        {
            Enemy[] all = FindObjectsOfType<Enemy>();
            Enemy result = GenericsTool.FindMax((a) => a.hp, all);
            result.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (GUILayout.Button("获取最小血量的敌人"))
        {
            Enemy[] all = FindObjectsOfType<Enemy>();
            Enemy result = GenericsTool.FindMin(a => a.hp, all);
            result.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        if (GUILayout.Button("获取距离最近的敌人"))
        {
            Enemy[] all = FindObjectsOfType<Enemy>();
            Vector3 Start = Camera.main.transform.position;
            Enemy result = GenericsTool.FindMin(a => Vector3.Distance(Start,a.transform.position), all);
            result.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        if (GUILayout.Button("按血量从大到小排序"))
        {
            Enemy[] all = FindObjectsOfType<Enemy>();
            all = GenericsTool.SortDesc(e => e.hp, all, out int count);
            print($"算法次数 {count}");
            for (int i = 0; i < all.Length; i++)
            {
                //print(all[i].name);
                all[i].transform.Translate(Vector3.up * (all.Length - i) / 2);
            }
        }
        if (GUILayout.Button("优化版：按血量从大到小排序"))
        {
            Enemy[] all = FindObjectsOfType<Enemy>();
            all = GenericsTool.NewSortDesc(e => e.hp, all,out int count2);
            print($"优化后的算法次数 {count2}");
            for (int i = 0; i < all.Length; i++)
            {
                //print(all[i].name);
                all[i].transform.Translate(Vector3.up*(all.Length-i)/2);
            }
        }
        if (GUILayout.Button("全部重置"))
        {
            Enemy[] all = FindObjectsOfType<Enemy>();
            for (int i = 0; i < all.Length; i++)
            {
                all[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                all[i].transform.position = new Vector3(all[i].transform.position.x, 0.5f, all[i].transform.position.z);
            }
        }
    }
}
