using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        //activates when mose is leftclicked
        if (Input.GetMouseButtonDown(0))
        {
            //Get the position of where the mouse is at on the screen
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            //We check the conditions of there is a ball and also if the mouse position is within the ball collider.
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
            {
                //we draw a line from the ballobject position to the mouse position
                drawnLine = lineFactory.GetLine(ballObject.transform.position, startLinePos, 0.2f, Color.white);
                drawnLine.EnableDrawing(true);
            }
        }
        //when the person lets go of his left click, then the like will disappear and stop drawing then updates the velocity of the ball
        //based on the length of the line drawn.
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            drawnLine.EnableDrawing(false);

            // Update the velocity of the white ball.
            HVector2D v = new HVector2D(-(drawnLine.end - drawnLine.start).x, -(drawnLine.end - drawnLine.start).y);
            ball.Velocity = v;

            drawnLine = null;            
        }
        //updates the line based on the mouse position
        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    //public void Clear()
    //{
    //    var activeLines = lineFactory.GetActive();

    //    foreach (var line in activeLines)
    //    {
    //        line.gameObject.SetActive(false);
    //    }
    //}
}
