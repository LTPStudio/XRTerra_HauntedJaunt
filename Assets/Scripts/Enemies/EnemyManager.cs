using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject[] enemies;
    public enum EnemyState { Wander, Scatter, Chase, Flee, Freeze }
    public EnemyState enemyState = EnemyState.Wander;

    public void EnabledEnemies(bool isEnabled)
    {
        foreach (GameObject enemy in enemies)
        {
            print(enemy.name + " is " + isEnabled);
            enemy.GetComponent<NavMeshAgent>().isStopped = !isEnabled;
        }
    }

    private void Awake()
    {
       if (instance == null)
        {
            instance = this;
        } 
    }

    void Start()
    {
        
    }

    //void UpdateEnemyState(EnemyState newEnemyState)
    //{
    //    switch (enemyState)
    //    {
    //        case EnemyState.Wander:
    //            foreach (WaypointControl ctl in enemies)
    //            {
    //                ctl.enemyState = WaypointControl.EnemyState.Wander;
    //            }
    //            break;
    //        case EnemyState.Scatter:
    //            foreach (WaypointControl ctl in enemies)
    //            {
    //                ctl.enemyState = WaypointControl.EnemyState.Scatter;
    //            }
    //            break;
    //        case EnemyState.Chase:
    //            foreach (WaypointControl ctl in enemies)
    //            {
    //                ctl.enemyState = WaypointControl.EnemyState.Chase;
    //            }
    //            break;
    //        case EnemyState.Flee:
    //            foreach (WaypointControl ctl in enemies)
    //            {
    //                ctl.enemyState = WaypointControl.EnemyState.Flee;
    //            }
    //            break;
    //    }

    //}
}
