using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] keys;

    private void Start()
    {
        foreach (GameObject key in keys)
        {
            key.SetActive(false);
        }
    }

    public void KeyCollected(int keyId)
    {
        print(keyId);
        keys[keyId].SetActive(true);
    }
}
