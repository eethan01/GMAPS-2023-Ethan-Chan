using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;

        float dx = 1.0f *dt;
        float dy = 0f;
        float dz = 0f;

        transform.Translate(new Vector3(dx,dy,dz));
    }
}
