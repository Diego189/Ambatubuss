using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed; 
    public Transform[] patrolPoints; 
    public float waitTime; // Time delay between reaching a patrol point and moving to the next
    int currentPointIndex;

    bool once; // This variable is used to make sure the coroutine is called only one time 
    void Update()
    {
        // Checks whether the current transform position is at a patrol point 
        if (transform.position != patrolPoints[currentPointIndex].position) {
       
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime); // Moves the enemy towards the current patrol point 
        }
        else // If the eneymy is at a patrol point, enter
        {
            if (once == false) // Makes sure coroutine is called only once
            {
                once = true;
                StartCoroutine(Wait()); // Starts wait time when the enemy is standing on a waypoint 
                IncreaseIndex(); // Increases the index of the current patrol point 
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
    }

    void IncreaseIndex()
    {
        if (currentPointIndex + 1 < patrolPoints.Length) // If the the next current point index exists
        {
            currentPointIndex++;
        }
        else // If not, reset the index
        {
            currentPointIndex = 0;
        }

        once = false;
    }
}
