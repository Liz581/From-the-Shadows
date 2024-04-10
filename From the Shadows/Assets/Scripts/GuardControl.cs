using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float moveSpeed = 3f; // Speed of the enemy
    public float chaseSpeed = 5f; // Speed when chasing the player
    public float chaseRange = 10f; // Detection range for player
    public float fieldOfViewAngle = 60f; // Field of view angle for player detection
    public float maxChaseDistance = 20f; // Maximum distance for player detection
    public Transform player; // Reference to the player's transform
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component attached to the enemy
        SetDestination(); // Set the initial destination to the first waypoint
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

        // Check if the player is within detection range and in the field of view and within maximum chase distance
        if (Vector3.Distance(transform.position, player.position) <= maxChaseDistance &&
            Vector3.Distance(transform.position, player.position) <= chaseRange &&
            InFieldOfView(player))
        {
            ChasePlayer();
        }
        else
        {
            // If the enemy is not chasing, continue patrolling
            Patrol();
        }
    }

    void Patrol()
    {
        // If the enemy reaches the current waypoint, move to the next one
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            SetDestination(); // Set the new destination
        }
    }

    void ChasePlayer()
    {
        // Set the destination to the player's position to chase
        navMeshAgent.SetDestination(player.position);
        navMeshAgent.speed = chaseSpeed; // Increase speed when chasing the player
    }

    bool InFieldOfView(Transform target)
    {
        Vector3 directionToTarget = target.position - transform.position;
        float angle = Vector3.Angle(directionToTarget, transform.forward);
        if (angle < fieldOfViewAngle * 0.5f)
        {
            return true;
        }
        return false;
    }
}
