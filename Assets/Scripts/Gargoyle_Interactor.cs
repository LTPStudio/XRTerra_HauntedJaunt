using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gargoyle_Interactor : MonoBehaviour
{
    public TMP_Text alert;
    public Cinemachine.CinemachineVirtualCamera vcam; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Introduction();
        }
    }

    public void Introduction()
    {
        //hide alert
        //disable player movement 
        //stop ghosts searching (ghosts pause or go to spawn point)
        //switch camera priority

        //establish camera for cutscene
        GameManager.instance.vc_cutscene = vcam;
        //change gamemanager to ShowCutScene
        GameManager.instance.ShowCutSceneScreen();
        //begin dialogue text
        GetComponent<DialogueTrigger>().TriggerDialogue();

        //
    }

    public void EndIntroduction()
    {
        alert.gameObject.SetActive(false);
    }
}
