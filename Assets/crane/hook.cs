using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{
    bool picked = false;
    public float height = 8f;
    public GameObject pully_obj;
    public bool getpicked()
    {
        return picked;
    }

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
            Vector3 p = pully_obj.transform.position;
            p.y = p.y - height;
            this.transform.position = p;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            picked = false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pully")
        {
            //do things
            Debug.Log("collided wotih");
            picked = true;
            //this
        }
        
    }
}
