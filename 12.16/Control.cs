using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Control : MonoBehaviour
{
    //TODO:修改代码，避免 != null
    //private bool[] IsRoate;
    private RaycastHit getHit;
    private Transform buffer; //能简化尽可能简化
    private int layerMask;
    private bool same;
    private Camera mainCamera;
    void Start()
    {
        //IsRoate = new bool[cubes.Length];
        layerMask = (1 << 8);
        //print(LayerMask.NameToLayer("Cubes"));
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray screenRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(screenRay, out getHit, 100, layerMask))
            {
                print(getHit.transform.name);
                if (buffer != getHit.transform)
                {
                    buffer = getHit.transform;
                    same = false;
                }
                else
                {
                    same = true;
                }
            }
        }
        if (!ReferenceEquals(buffer,null) && same == false)
        {
            buffer.Rotate(Vector3.up, 45 * Time.deltaTime);
        }
    }
}