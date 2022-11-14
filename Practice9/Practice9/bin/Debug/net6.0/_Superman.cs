using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    private Vector3[] target = new Vector3[20];
    private int counter;
    public float force;
    private Rigidbody rb;
    private Vector3 vector;
    private GameObject[] BadGuys;
    void Start()
    {
        BadGuys = GameObject.FindGameObjectsWithTag("BadGuy") as GameObject[];
        for (int i = 0; i < BadGuys.Length; i++)
            target[i] = BadGuys[i].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < target.Length)
        {
            Vector3 enemy = target[counter];
            transform.position = Vector3.MoveTowards(transform.position, enemy, Time.deltaTime * 10);
            transform.Rotate(0, 90, 0);
            transform.LookAt(enemy);
            if (transform.position == enemy)
                counter++;
        }
        if (counter > target.Length - 1)
        {
            counter = 0;
        }
        /*else
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * 10);*/
    }


    private void OnCollisionEnter(Collision collision)
    {
        rb = BadGuys[counter].GetComponent<Rigidbody>();
        
        if (counter < target.Length)
        {
            vector = target[counter] - transform.position;
            rb.AddForce(vector * force, ForceMode.Impulse);
        }
    }
}
