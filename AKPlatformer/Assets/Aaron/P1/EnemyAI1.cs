using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI1 : MonoBehaviour
{
    //Reference to our points
    public List<Transform> points;
    //the next int value for the next index in our list
    public int nextId;
    //will be used to change the nextId #
    private int idChangeValue = 1;
    //Used to set the speed for our enemy movement
    public float speed;

    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveToNextPoint()
    {
        //set a goalpoint using the next point in transform list
        Transform goalPoint = points[nextId];
        //flip our enemy's transform to look at points direction
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Check the distance between the enemy and the goalpoint to trigger next point

        if (Vector2.Distance(transform.position, goalPoint.position)< 1f)
        {
            //check if we are at the end of the line make the change -1
            if (nextId == points.Count - 1)
            {
                idChangeValue = -1;
            }
            //check if we are at the start of the line, make the change to +1{
            if (nextId == 0)
            {
                idChangeValue = 1;
            }
            //apply the change on the nextId
            nextId += idChangeValue;
        }
    }
}
