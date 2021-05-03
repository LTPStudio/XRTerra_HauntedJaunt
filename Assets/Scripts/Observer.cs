using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform Player;
    public Transform grabTransform;


    bool isPlayerInRange = false;




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = true;
            GameOver_Trigger.instance.CaughtPlayer();
        }
    }

    // void OnTriggerExit(Collider other){
    //     if (other.tag == "Player"){
    //         isPlayerInRange = false;
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            //Vector3 direction = Player.position - transform.position;
            //direction.y += 1;

            //Ray ray = new Ray(transform.position, direction);
            //RaycastHit hit;

            //if (Physics.Raycast(ray, out hit))
            //{
            //    if (hit.collider.tag == "Player")
            //    {
            //        print("Player Caught");
            //        GameOver_Trigger.instance.CaughtPlayer();
            //    }
            //}
            GameOver_Trigger.instance.CaughtPlayer();
            Player.position = grabTransform.position;
        }
    }

    private void OnDisable()
    {

    }
}
