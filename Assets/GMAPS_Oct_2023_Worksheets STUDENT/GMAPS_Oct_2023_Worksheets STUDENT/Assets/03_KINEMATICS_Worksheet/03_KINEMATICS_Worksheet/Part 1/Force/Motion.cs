using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        //Get the delta time
        float dt = Time.deltaTime;
        //set the change in x-axis position
        float dx = 1.0f *dt;
        //set the change in y-axis position
        float dy = 0f;
        //set the change in z-axis position
        float dz = 0f;
        //Translate the object based on the dx, dy and dz floats.
        transform.Translate(new Vector3(dx,dy,dz));
    }
}
