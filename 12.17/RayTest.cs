using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public Transform start;
    public Transform end;
    private RaycastHit hit;
    private List<MeshRenderer> buffers = new List<MeshRenderer>();
    public GameObject test;
    private void Start()
    {
        //try
        //{
        //    print(test.transform.position);
        //}
        //catch (Exception e)
        //{
        //    Application.OpenURL("https://stackoverflow.com/search?q=" + e.Message);
        //    Application.OpenURL("https://www.google.com/search?q=" + e.Message);
        //    Application.OpenURL("https://answers.unity3d.com/search.html?q=" + e.Message);
        //    throw;
        //}

    }

    private void Update()
    {
        float x = Input.GetAxis("Vertical");
        end.Translate(-Time.deltaTime*5f*x*Vector3.right);

        Vector3 startPos = start.position;
        Vector3 endpos = end.position;
        //print($"{startPos} + {endpos}");
        //Ray r = new Ray(startPos, endpos);
        Ray r = new Ray(startPos, (endpos-startPos)); //这里需要的是一个方向而不是一个点
        //print(r.direction);
        Debug.DrawLine(startPos, endpos, Color.yellow);
        //Debug.DrawLine(startPos,,Color.red);  一个是起点，一个是终点
        //if (Physics.Raycast(r,out hit))
        //{
        //    print(hit.transform.name);
        //}

        RaycastHit[] result = Physics.RaycastAll(r);
        if (result.Length > 1)
        {
            foreach (MeshRenderer m in buffers)
            {
                m.material.color = Color.white;
            }
            buffers.Clear();
            foreach (var t in result)
            {
                if (!buffers.Contains(t.transform.GetComponent<MeshRenderer>()))
                {
                    buffers.Add(t.transform.GetComponent<MeshRenderer>());
                    t.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
        else
        {
            foreach (MeshRenderer m in buffers)
            {
                m.material.color = Color.white;
            }
            buffers.Clear();
        }
    }
}
