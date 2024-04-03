using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class GuardControl : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float moveSpeed = 3f; // Speed of the enemy
    public float stoppingDistance = 0.1f; // Distance at which the enemy considers it has reached the waypoint
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private UnityEngine.AI.NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // Get the NavMeshAgent component attached to the enemy

        // Check if there are waypoints and NavMeshAgent is available
        if (waypoints.Length > 0 && navMeshAgent != null)
        {
            SetDestination(); // Set the initial destination to the first waypoint
        }
        else
        {
            //Debug.LogError("No waypoints assigned or NavMeshAgent component missing.");
        }
    }

    void SetDestination()
    {
        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position); // Set the destination to the current waypoint
    }

    void Update()
    {
        // If NavMeshAgent is not available, return
        if (navMeshAgent == null)
            return;

        // If the enemy reaches the current waypoint, move to the next one
        if (navMeshAgent.remainingDistance < stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            SetDestination(); // Set the new destination
        }
    }

}
