using System;
using System.Collections;

using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public Color foodColor;
    public float Distance = 2f;
    private GameObject[] foods;
    private Rigidbody rd;
    bool foodfound = false;
    void Start()
    {

        foods = GameObject.FindGameObjectsWithTag("Food");
        rd = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (rd.velocity.magnitude <= 0.1f)
        //{
        //    this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //    Debug.Log("stuck");
        //}

        GameObject closestFood = null;
        float closestDistance = Mathf.Infinity;
        if (!foodfound)
        {
            for (int i = 0; i < foods.Length; i++)
            {
                if (foods[i] == null)
                {
                    for (int j = i; j < foods.Length - 1; j++)
                    {
                        foods[j] = foods[j + 1];
                    }
                    Array.Resize(ref foods, foods.Length - 1);
                    continue;
                }
                if (Vector3.Distance(this.transform.position, foods[i].transform.position) > Distance)
                {
                    float distance = Vector3.Distance(transform.position, foods[i].transform.position);
                    if (distance < closestDistance)
                    {
                        closestFood = foods[i];
                        closestDistance = distance;
                    }
                }
                if (Vector3.Distance(this.transform.position, foods[i].transform.position) < Distance)
                {


                    if (foods[i].GetComponent<Renderer>().material.color == foodColor)
                    {

                        float distance = Vector3.Distance(transform.position, foods[i].transform.position);
                        if (distance < closestDistance)
                        {
                            closestFood = foods[i];
                            closestDistance = distance;
                        }
                    }
                    else
                    {
                        for (int j = i; j < foods.Length - 1; j++)
                        {
                            foods[j] = foods[j + 1];
                        }
                        Array.Resize(ref foods, foods.Length - 1);
                        continue;
                    }
                }
            }


            if (closestFood != null)
            {
                transform.LookAt(closestFood.transform);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                // Debug.Log("");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            //do things
            // Debug.Log("collided wotih");
            //other.gameObject.Destroy=true;
            foodfound = true;
            StartCoroutine(stopp());

            Destroy(other.gameObject,2f);
            //this
        }

    }
    IEnumerator stopp( )
    {
        
            
        yield return new WaitForSeconds(2);
        foodfound = false;

    }
}
