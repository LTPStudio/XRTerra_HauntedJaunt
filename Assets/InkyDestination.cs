using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkyDestination : MonoBehaviour
{
    public Transform playerPos;
    public Transform blinkyPos; 



    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position - (blinkyPos.position - playerPos.position);
    }
}
