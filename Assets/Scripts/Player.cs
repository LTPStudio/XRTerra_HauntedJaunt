using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int keyCount; 

    public int globCount = 25;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        GameManager.instance.globCount = globCount;
    }

    public void SubtractGlobCount(int amount)
    {
        globCount -= amount;
        GameManager.instance.globCount = globCount;
        GameManager.instance.UpdateGlobCount();
    }

    public void AddToGlobCount()
    {
        globCount++;
        GameManager.instance.globCount = globCount;
        GameManager.instance.UpdateGlobCount();
    }

    public void AddToKeyCount()
    {
        keyCount++;
    }
}
