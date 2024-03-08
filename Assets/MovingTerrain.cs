using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTerrain : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject[] waypoints;
    private int currWaypoint = 0;
    private int direction = 1;

    [SerializeField] private AudioSource suddenMoveSFX;
    [SerializeField] private float[] accelerationSpeed;
    [SerializeField] private int pauseTime = 60;
    private int pauseCountdown = 0;
    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseCountdown != 0)
        {
            pauseCountdown--;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currWaypoint].transform.position, Time.deltaTime * speed);
            
            if (Vector2.Distance(waypoints[currWaypoint].transform.position, transform.position) < .1f)
            {
                currWaypoint += direction;
                pauseCountdown = pauseTime;
                speed = 0f;

                if (currWaypoint >= waypoints.Length || currWaypoint < 0)
                {
                    direction = -direction;
                    currWaypoint += direction;
                }
            }
            else
            {
                speed *= accelerationSpeed[currWaypoint];
            }
        }
    }
}
