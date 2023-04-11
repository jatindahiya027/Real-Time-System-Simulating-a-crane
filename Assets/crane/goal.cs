using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class goal : MonoBehaviour
{
    // Start is called before the first frame update
    public float minDistance = 27f;
    public float maxDistance = 120f;
    public GameObject target;
    public GameObject fgoal;
    public hook hook;
    public Text text;
    void Start()
    {
        text.text = "";
        objplace();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objplace();
        }
    }
    private void objplace()
    {
        
        // Generate a random distance within the desired range
        Vector3 randomDistance = new Vector3(Random.Range(minDistance, maxDistance),4f, Random.Range(minDistance, maxDistance));
        float i = Random.Range(-1, 1);
        if (i < 0)
        {
            randomDistance.x = randomDistance.x * -1f;
        }
        i = Random.Range(-1, 1);
        if (i < 0)
        {
            randomDistance.z = randomDistance.z * -1f;
        }
        // Multiply the direction vector by the random distance
        Vector3 randomPosition =  randomDistance;
       // randomPosition.y = 4f;
      //  Debug.Log(randomPosition + " " + randomDistance);
        target.transform.position = randomPosition;
        thisplace();

    }
    private void thisplace()
    {
        // Generate a random distance within the desired range
        do
        {


            Vector3 randomDistance = new Vector3(Random.Range(minDistance, maxDistance), Random.Range(20f, 60f), Random.Range(minDistance, maxDistance));
            float i = Random.Range(-1, 1);
            if (i < 0)
            {
                randomDistance.x = randomDistance.x * -1f;
            }
            i = Random.Range(-1, 1);
            if (i < 0)
            {
                randomDistance.z = randomDistance.z * -1f;
            }
            // Multiply the direction vector by the random distance
            Vector3 randomPosition = randomDistance;

           

            fgoal.transform.position = randomPosition;
           
        } while (Vector3.Distance(fgoal.transform.position, target.transform.position) < 90f);
        //Debug.Log(Vector3.Distance(fgoal.transform.position, target.transform.position));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "box")
        {
            //do things
            Debug.Log("box entered");
            if (hook.getpicked() == false)
                StartCoroutine(Fade());
            else
                text.text = "Drop Object";
            // thisplace();
            //picked = true;
            //this
        }

    }
    IEnumerator Fade()
    {
        Debug.Log("hurray");
        text.text = "Sucess";
        yield return new WaitForSeconds(2f);
        text.text = "";
        objplace();

    }
}
