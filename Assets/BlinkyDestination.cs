using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkyDestination : MonoBehaviour
{
    public Transform playerPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position;
    }
}
