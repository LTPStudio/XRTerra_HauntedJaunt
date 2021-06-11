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
    public enum GhostType { Blinky, Pinky, Inky, Clyde };
    public GhostType ghostType;
    Player player;
    public bool PlayerIsClose;

    public float closeRadius = 5.0F;
    public float chaseSpeed = 2f;



    private void Start()
    {
        player = Player.instance;
        enemyManager = EnemyManager.instance;
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetScatterDestination()
    {
        agent.SetDestination(scatterPoints[0].position);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyManager.enemyState == EnemyManager.EnemyState.Chase)
        {
            agent.speed = chaseSpeed;
            if (Vector3.Distance(player.transform.position, transform.position) < closeRadius)
            {
                PlayerIsClose = true;
                agent.SetDestination(player.transform.position);

            }
            else
            {
                PlayerIsClose = false;
                agent.SetDestination(chaseDestination.position);

            }
        }
        if (enemyManager.enemyState == EnemyManager.EnemyState.Scatter)
        {
            agent.speed = 1;
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
