using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLightDelay : MonoBehaviour
{
public AudioSource audio1, audio2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForRandomSeconds(audio1));
        StartCoroutine(WaitForRandomSeconds(audio2));
    }

    IEnumerator WaitForRandomSeconds(AudioSource audio){
        yield return new WaitForSeconds(Random.Range(.5f,4f));
        audio.Play();
    }
}
