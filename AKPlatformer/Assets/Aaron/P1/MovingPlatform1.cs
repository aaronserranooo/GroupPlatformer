using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class MovingPlatform1 : MonoBehaviour
{
    public Transform[] platformPosition = new Transform[2];
    int direction = 1;
    public float speed;
    Vector2 target;
    // Update is called once per frame
    void Update()
    {
        target = currentMovementTarget();

        //need to set our distance and change direction
        float distance = (target - (Vector2)platformPosition[0].position).magnitude;

        if (distance <= .5f)
        {
            direction *= -1;
        }
    }

    private void FixedUpdate()
    {
        platformPosition[0].position = Vector2.Lerp(platformPosition[0].position, target, speed * Time.deltaTime);
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {   
            //return the start position from our array 
            return platformPosition[1].position;
        }
        else
        {
            //return the end position from our array
            return platformPosition[2].position;
        }
    }

    private void OnDrawGizmos()
    {   // things are not null draw a line between our start and endpoint
        if (platformPosition[0] != null && platformPosition[1] != null && platformPosition[2] != null)
        {
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[1].transform.position);
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[2].transform.position);
        }
    }
}
