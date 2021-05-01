using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private int globCount = 0;

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
