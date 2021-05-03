using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableEffects : MonoBehaviour
{
    public GameObject effectsPrefab;
    public GameObject createdPrefab;
    // Start is called before the first frame update
    private void OnEnable()
    {
        createdPrefab = Instantiate(effectsPrefab, transform.position, transform.rotation);
    }

    private void OnDisable()
    {
        Destroy(createdPrefab);
    }
}
