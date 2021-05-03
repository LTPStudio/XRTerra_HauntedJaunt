using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateHandler : MonoBehaviour
{
    EnemyManager enemyManager;
    public Transform[] scatterPoints;
    public Transform chaseDestination;
    NavMeshAgent agent;
    int currentIndex;

    void Awake()
    {

    }

    private void Start()
    {
        enemyManager = EnemyManager.instance;
        agent = GetComponent<NavMeshAgent>();
    }

    void UpdateEnemyState(bool isEnabled)
    {
        agent.enabled = isEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyManager.enemyState == EnemyManager.EnemyState.Chase)
        {
            agent.enabled = true;
            agent.SetDestination(chaseDestination.position);
        }
        if (enemyManager.enemyState == EnemyManager.EnemyState.Scatter)
        {
            agent.enabled = true;
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                currentIndex++;
                currentIndex %= scatterPoints.Length; //it'll loop back to zero and repeat forevs

                agent.SetDestination(scatterPoints[currentIndex].position);
            }
        }
        if (enemyManager.enemyState == EnemyManager.EnemyState.Flee)
        {
            agent.enabled = true;
        }
        if (enemyManager.enemyState == EnemyManager.EnemyState.Wander)
        {
            agent.enabled = true;
        }
        if (enemyManager.enemyState == EnemyManager.EnemyState.Freeze)
        {
            agent.enabled = false;
        }
    }

    private void OnDisable()
    {

    }
}
