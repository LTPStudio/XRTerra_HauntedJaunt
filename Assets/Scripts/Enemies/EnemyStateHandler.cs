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

    public void SetScatterDestination()
    {
        agent.SetDestination(scatterPoints[0].position);
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyManager.enemyState == EnemyManager.EnemyState.Chase)
        {

            agent.SetDestination(chaseDestination.position);
        }
        if (enemyManager.enemyState == EnemyManager.EnemyState.Scatter)
        {
  
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                currentIndex++;
                currentIndex %= scatterPoints.Length; //it'll loop back to zero and repeat forevs

                agent.SetDestination(scatterPoints[currentIndex].position);
            }
        }
        if (enemyManager.enemyState == EnemyManager.EnemyState.Flee)
        {
     
        }
        if (enemyManager.enemyState == EnemyManager.EnemyState.Wander)
        {
 
        }
        if (enemyManager.enemyState == EnemyManager.EnemyState.Freeze)
        {
 
        }
    }

    private void OnDisable()
    {

    }
}
