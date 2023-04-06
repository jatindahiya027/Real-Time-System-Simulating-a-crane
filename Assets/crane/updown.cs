using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updown : MonoBehaviour
{
    public float zDelta = 0.001f;
    public int pointIndex = 1;
    public GameObject pully;
    private LineRenderer lineRenderer;
    //private GameObject placedObject;
    bool up = false;
    bool down = false;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        int pointCount = lineRenderer.positionCount;
        Vector3 lastPosition = lineRenderer.GetPosition(pointCount - 1);
        //placedObject = Instantiate(pully, lastPosition, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            up = true;
           
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            up = false;
        }
         if (Input.GetKeyDown(KeyCode.W))
        {
            down = true;
            
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            down = false;
        }
        if (up)
        {
            
            Vector3 position = lineRenderer.GetPosition(pointIndex);
            position.z -= zDelta;
            if (position.z < -0.9)
            {
                position.z = -0.89f;
            }
            lineRenderer.SetPosition(pointIndex, position);
        }
        if (down)
        {
            Vector3 position = lineRenderer.GetPosition(pointIndex);
            position.z += zDelta;
            if (position.z > -0.1)
            {
                position.z = -0.11f;
            }
            lineRenderer.SetPosition(pointIndex, position);
        }
        int pointCount = lineRenderer.positionCount;
        Vector3 lastPosition = lineRenderer.GetPosition(pointCount - 1);
        //placedObject.transform.position = lastPosition;

        Vector3 p = new Vector3(0f, 0f, lastPosition.z);
        //Debug.Log(up +" up " +down+" down");
        pully.transform.localPosition = p;
        //Debug.Log(pully.transform.position);
    }
}
