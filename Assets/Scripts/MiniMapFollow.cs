using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform Player; 

    public float camHeight = 10;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Player.position.x, camHeight, Player.position.z);
        this.transform.position = pos;
        
    }
}
