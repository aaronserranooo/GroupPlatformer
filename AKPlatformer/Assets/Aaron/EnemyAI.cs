using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //reference for my waypoints
    public List<Transform> points;
    //the in value for my indexed list
    public int nextId;
    //declare a int to help us change our nextID
    private int idChangeValue = 1;
    //sets our speed of the enemy
    public float speed = 2;


    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveToNextPoint()
    {
        //Declare and set a transform to our next point
        Transform goalPoint = points[nextId];
        //Flip the enemy via the transform to look at the points direction
        //Might need to change based off of the sprites natural face 
        if (goalPoint.transform.position.x > transform.position.x)
        {                                    //1
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {                                    //-1
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Move the enemy towards our point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

    }
}
