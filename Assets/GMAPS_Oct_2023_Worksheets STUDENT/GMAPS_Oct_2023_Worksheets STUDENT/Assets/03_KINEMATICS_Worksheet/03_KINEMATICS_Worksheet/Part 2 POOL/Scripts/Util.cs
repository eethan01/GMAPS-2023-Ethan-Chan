using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    //Math formula for the distance between p1 and p2
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        return (p2 - p1).Magnitude();

    }


}

