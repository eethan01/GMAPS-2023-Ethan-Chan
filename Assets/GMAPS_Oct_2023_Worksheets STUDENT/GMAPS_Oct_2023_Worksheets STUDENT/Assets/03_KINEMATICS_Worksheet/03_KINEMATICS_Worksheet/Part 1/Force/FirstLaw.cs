using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        //Get rigidbody component of the gameobject
        rb = GetComponent<Rigidbody>();
        //Apply a force onto the gameobject
        rb.AddForce(1, 0, 0, ForceMode.Impulse);
     }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

