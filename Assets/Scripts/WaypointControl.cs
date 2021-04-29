using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointControl : MonoBehaviour
{
    public Transform[] waypoints;

    NavMeshAgent agent;
    int currentIndex;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentIndex++;
            currentIndex %= waypoints.Length; //it'll loop back to zero and repeat forevs

            agent.SetDestination(waypoints[currentIndex].position);
        }
    }
}
