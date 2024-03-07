using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currWaypoint = 0;
    private int direction = 1;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currWaypoint].transform.position, transform.position) < .1f)
        {
            currWaypoint += direction;

            if (currWaypoint >= waypoints.Length || currWaypoint < 0)
            {
                direction = -direction;
                currWaypoint += direction;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currWaypoint].transform.position, Time.deltaTime * speed);
    }
}
