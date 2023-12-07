using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        //OtherPlayers = FindObjectsOfType<SoccerPlayer>();
        //SoccerPlayer[] temp = new SoccerPlayer[OtherPlayers.Length - 1];
        //int i = 0;
        //foreach (SoccerPlayer p in OtherPlayers)
        //{
        //    if(p != this)
        //    {
        //        temp[i] = p;
        //        i++;
        //    }
        //}
        //OtherPlayers = temp;
        //Debug.Log(OtherPlayers);
        // Initialize OtherPlayers array by finding all SoccerPlayer objects in the scene excluding the current one
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();
        //Check if the current player is the captain
        if (IsCaptain)
        {
            FindMinimum();
        }
    }

    //float Magnitude(Vector3 vector)
    //{

    //}

    //Vector3 Normalise(Vector3 vector)
    //{

    //}

    //float Dot(Vector3 vectorA, Vector3 vectorB)
    //{

    //}

    //SoccerPlayer FindClosestPlayerDot()
    //{
    //    SoccerPlayer closest = null;

    //    return closest;
    //}

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            //This line calculates all of the possible pairs of each player excluding themselves by using LINQ's Where.
            var playerPairs = OtherPlayers.Where(player => player != other);
            //Then for each soccerplayer object we find in the array playerpairs, we draw a ray from the position of the player to the otherplayer.
            //We do this by finding the distance between the two using simple subtraction of other - player.
            foreach (SoccerPlayer player in playerPairs)
            {
                Debug.DrawRay(player.transform.position, (other.transform.position - player.transform.position), Color.black);
            }
        }
    }

    void Update()
    {
        //DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);
        // Check if the current player is the captain
        if (IsCaptain)
        {
            // Update the angle based on the horizontal input and rotation speed
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            // Rotate the player around the y - axis based on the  angle
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            // Draw a ray in the forward direction of the captain
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            DrawVectors();
            // Find the player with the closest angle to the captain
            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            // Set the color of the target player to green
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;
            // Set the color of all other players to white
            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }

        }
    }

    void FindMinimum()
    {
        // Loop to find the minimum of a random height value
        for (int i = 0; i < 10; i++)
        {
            float height = Random.Range(5f, 20f);
            Debug.Log(height);
        }
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;
        //Create a loop based on the value of the array of OtherPlayers
        for(int i = 0; i < OtherPlayers.Length; i++)
        {
            //calculate the vector from the current player to the target player.
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.position;
            // Normalize the vector
            Vector3 normalizedToPlayer = toPlayer.normalized;
            // Calculate the dot product between the captain's forward vector and the normalized direction to the player
            float dot = Vector3.Dot(transform.forward, normalizedToPlayer);
            //Calculate the angle and convert it to degrees
            float angle = Mathf.Acos(dot);
            angle = angle * Mathf.Rad2Deg;

            //Codition if the angle calculated currently of the new player is less than the existing smallest angle
            if(angle < minAngle)
            {
                //update the niminum angle to the new value and also update the new player
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }
        //return the player with the closest angle
        return closest;
    }
}


