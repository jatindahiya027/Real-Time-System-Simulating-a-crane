using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour
{
    public float moveSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (transform.localPosition.y < 1.85)
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            Debug.Log("pressed q");
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if(transform.localPosition.y>0.3)
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            Debug.Log("pressed e");
        }
    }
}
