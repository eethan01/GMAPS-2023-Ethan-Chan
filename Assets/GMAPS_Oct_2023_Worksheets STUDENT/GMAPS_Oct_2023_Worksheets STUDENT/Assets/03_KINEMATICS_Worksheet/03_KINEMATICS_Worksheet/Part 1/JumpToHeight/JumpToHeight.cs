using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = height
        //calculate the jump height based upon the gravity and also the set height given
        float u = Mathf.Sqrt(2 * Physics.gravity.magnitude * height);
        //Apply the jump force onto the gameobject
        rb.velocity = new Vector3(0, u, 0);
    }

    private void Update()
    {
        // activate the jump function when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}

