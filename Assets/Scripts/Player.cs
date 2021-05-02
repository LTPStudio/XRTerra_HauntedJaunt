using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField]
    public bool[] keysCollected = new bool[3]; 

    public int globCount = 25;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SubtractGlobCount(int amount)
    {
        globCount -= amount;
        GameManager.instance.UpdateGlobCount(globCount);
    }

    public void AddToGlobCount()
    {
        globCount++;
        GameManager.instance.UpdateGlobCount(globCount);
    }
}
