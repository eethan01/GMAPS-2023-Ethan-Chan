using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate    ()
    {
        //First we calc the distance between the player and the planet.
        gravityDir = planet.position - transform.position;
        //Then we find the perpendicular vector to gravitydir and normalize it.
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0f);
        moveDir = moveDir.normalized * -1f;

        //Apply the movement force onto the astronaut gameobject.
        rb.AddForce(moveDir * force);

        // Apply the gravitational force onto the astronaut.
        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        //Then we find the agle between planet.up and the negative of gravitynorm to rotate the astronaut accordingly
        float angle = Vector3.SignedAngle(planet.up, -gravityNorm, Vector3.forward);

        //apply the angle change onto the astronaut
        rb.MoveRotation(Quaternion.Euler(0,0,angle));
        //Debug.Log(moveDir);
        //Arrow for the gravity
        DebugExtension.DebugArrow(transform.position, gravityDir,  Color.red);
        //Arrow for the movedir
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
    }

}


