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
    public bool dontChase = false;

    public void EnabledEnemies(bool isEnabled)
    {
        //if is true enable 
        foreach (GameObject enemy in enemies)
        {

            enemy.GetComponent<NavMeshAgent>().isStopped = !isEnabled;
        }
    }

    public void ActivateGhosts()
    {
        foreach (GameObject enemy in enemies)
        {

            enemy.SetActive(true);
            EnabledEnemies(false);
        }
    }

    public void StartChase()
    {
        StopAllCoroutines();
        if (dontChase) return;
        enemyState = EnemyState.Chase;
        //StartCoroutine(ChaseTime());

    }

    IEnumerator ChaseTime()
    {
        yield return new WaitForSeconds(30f);
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyStateHandler>().SetScatterDestination();
        }
        enemyState = EnemyState.Scatter;
    }

    public void ChangeToScatter()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyStateHandler>().SetScatterDestination();
        }
        enemyState = EnemyState.Scatter;
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
        foreach (GameObject enemy in enemies)
        {

            enemy.SetActive(false) ;
        }
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
