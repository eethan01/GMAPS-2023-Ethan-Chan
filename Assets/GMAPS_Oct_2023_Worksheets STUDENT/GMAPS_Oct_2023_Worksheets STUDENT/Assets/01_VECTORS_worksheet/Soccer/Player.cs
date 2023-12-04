using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform captain;
    public bool IsCaptain = true;
    public Player OtherPlayer;

    //float Magnitude(Vector3 vector)
    //{
    //    // Your code here
    //}

    //Vector3 Normalise(Vector3 vector)
    //{
    //    // Your code here
    //}

    //float Dot(Vector3 vectorA, Vector3 vectorB)
    //{
    //    // Your code here
    //}

    //float AngleToPlayer()
    //{
    //    // Steps to calculate the angle between the direction Captain is facing and 
    //    // the direction from Captain to Other
    //    // 1. A
    //    // 2. B
    //    // 3. Calculate the angle between the vectors from A and B
    //    //    3.1 Calculate the dot product between A and B
    //    //       3.1.1 Calculate the magnitude of the vector from Captain to Other (A)
    //    //       3.1.2 Normalise the vector from Captain to Other
    //    //       3.1.3 Calculate the dot product of the normalised vectors A and B
    //    //    3.2 From the dot product, calculate the actual angle between A and B
    //    //       3.2.1 Take the arc cosine (acos) of the dot product (because if 
    //    //             both vector are normalised, the dot product equals the cos
    //    //             of the angle between vectors A and B.
    //    //       3.2.2 The acos angle returned is in radians. We must convert to
    //    //             degrees.

    //    // A
    //    // Steps to draw the arrow that represents the vector from Captain to Other 
    //    // 1. Find the vector from Captain to Other
    //    //     1.1 Find the position of Captain (A -- from)
    //    //     1.2 Find the position of Other (B -- to)
    //    //     1.3 Calculate B-A to get the vector from A to B
    //    // 2. Draw the arrow to represent visually the vector AB
    //    //

    //    // Your code here

    //    // B
    //    // Steps to draw an arrow that represents which direction Captain is facing
    //    // 1. Find which vector to draw as an arrow
    //    //    1.1 The transform.forward vector of Captain
    //    // 2. Draw the arrow to represent visually the the transform.forward vector of Captain
    //    DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);

    //    // CALCULATING THE ANGLE

    //    // Your code here
    //    // ...

    //    // Your code here
    //}

    void Update()
    {

        if (IsCaptain)
        {
            //Draw an arrow from the position of the captain to the player1
            DebugExtension.DebugArrow(captain.position, transform.position, Color.black, 60f);
            //We get the coordinates of where the captain is
            Vector3 position = captain.position;
            //Find the rotation of the captain of where he is facing.
            Quaternion rotation = captain.rotation;
            //Now we find the vector for the captain in the forward direction of him.
            Vector3 forwardCaptain = rotation * Vector3.forward;
            Vector3 playerDistance = transform.position - captain.position;

            //Draw the arrow of the vector
            DebugExtension.DebugArrow(captain.position, forwardCaptain, Color.blue);
            // Now we use the formula to get the dot product of the 2 vectors.
            float dotProduct = Vector3.Dot(forwardCaptain, playerDistance);
            Debug.Log(dotProduct);
            //We are calculating the magnitude of the product of the captain and player by using unity's .magnitude property
            float magnitudeProduct = forwardCaptain.magnitude * playerDistance.magnitude;
            //We caluclate the angle based on the formula
            float angleInRad = Mathf.Acos(dotProduct / magnitudeProduct);
            //Convert the value of angleInRad from radians to degrees using MathF.Rad2Deg
            float angle = Mathf.Rad2Deg * angleInRad;
            Debug.Log(angle);
        }

    }
}
