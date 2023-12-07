using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //First we calc the distance between the player and the planet.
        gravityDir = new HVector2D(planet.position) - new HVector2D(transform.position);
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);
        //Then we find the perpendicular vector to gravitydir and normalize it.
        moveDir.Normalize();
        moveDir *= -1f;
        //Apply the movement force onto the astronaut gameobject.
        rb.AddForce(moveDir.ToUnityVector2() * force);

        // Apply the gravitational force onto the astronaut.
        gravityNorm = gravityDir;
        gravityNorm.Normalize();

        rb.AddForce(gravityNorm.ToUnityVector2() * gravityStrength);
        //Then we find the agle between planet.up and the negative of gravitynorm to rotate the astronaut accordingly
        float angle = Vector3.SignedAngle(planet.up, -gravityNorm.ToUnityVector3(), Vector3.forward);
        //apply the angle change onto the astronaut
        rb.MoveRotation(Quaternion.Euler(0, 0, angle));
        //Arrow for the gravity
        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3(), Color.red);
        //Arrow for the movedir
        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);
    }
}
