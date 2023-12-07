using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        // Calculate the distance between the ball's position and the given point
        float distance = Util.FindDistance(Position, new HVector2D(x, y));
        // Check if the distance is less than or equal to the radius
        return distance <= Radius;
    }

    //public bool IsCollidingWith(Ball2D other)
    //{
    //    float distance = Util.FindDistance(Position, other.Position);
    //    return distance <= Radius + other.Radius;
    //}

    public void FixedUpdate()
    {
        // Update the physics of the ball based on time
        UpdateBall2DPhysics(Time.deltaTime);
        //HVector2D a = new HVector2D(8f, 5f);
        //HVector2D b = new HVector2D(8f, 3f);
        //float distance = Util.FindDistance(a, b);
        //Debug.Log(distance);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        // Calculate the displacement in the x and y directions
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;
        // Update the position of the ball
        Position.x += displacementX;
        Position.y += displacementY;
        // Update the GameObject's position based on the calculated position above
        transform.position = new Vector2(Position.x, Position.y);
    }
}

