using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowerCustom : MonoBehaviour
{   
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    public EntryScene entryScene;

    [SerializeField] private float speed = 2f;
    public bool isMoving = true;

    private void Update()
    {
        if (isMoving)
        {
            MoveTowardsWaypoint();
        }
    }

    private void MoveTowardsWaypoint()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length && entryScene.starts < 2)
            {
                {
                    // Stop moving when reaching the last waypoint 
                    isMoving = false;
                    switch (entryScene.starts)
                    {
                        case 0:
                            Debug.Log("Sent object stopped.");
                            entryScene.OnFirstObjectStopped();
                            entryScene.starts++;
                            Debug.Log("case 0: " + entryScene.starts);
                            break;
                        case 1:
                            Debug.Log("Sent object stopped.");
                            entryScene.OnSecondObjectStopped();
                            Debug.Log("case 1: " + entryScene.starts);
                            entryScene.starts++;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }
}