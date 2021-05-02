using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glob_interactable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().AddToGlobCount();
            Destroy(this.gameObject);
        }
        //maybe play sound? 
    }
}
