using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClydeDestination : MonoBehaviour
{
    public Transform playerPos; 



    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position + new Vector3(0, 0, -2);
    }
}
