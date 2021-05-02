using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointControl : MonoBehaviour
{
    public Transform[] scatterPoints;
    public enum EnemyState { Wander, Scatter, Chase, Flee }
    public EnemyState enemyState = EnemyState.Wander;

    NavMeshAgent agent;
    int currentIndex;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(PeriodicSearch());
        agent.SetDestination(scatterPoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentIndex++;
            currentIndex %= scatterPoints.Length; //it'll loop back to zero and repeat forevs

            agent.SetDestination(scatterPoints[currentIndex].position);
        }
    }
    IEnumerator PeriodicSearch()
    {
        yield return null;
        //while( enemyState == EnemyState.Chase)
        //{
        //    yield return new WaitForSeconds(1);
        //    agent.SetDestination(scatterPoints[0].position);

        //}

    }
}
