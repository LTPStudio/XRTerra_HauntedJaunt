using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gargoyle_Interactor : MonoBehaviour
{
    public TMP_Text alert;
    public Cinemachine.CinemachineVirtualCamera vcam;
    public DialogueTrigger introDialogue;
    public DialogueTrigger hasEnoughGlobsDialogue;
    public bool hadFirstInteraction = false;
    public bool gaveKey = false;
    [Range(0, 2)]
    public int keyID;

    public enum GargoyleState { Introduction, WaitingForGlobs, HasEnoughGlobs, EndInteractions };
    public GargoyleState goyleState = GargoyleState.Introduction;


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
            switch (goyleState)
            {
                case GargoyleState.Introduction:
                    Introduction();
                    break;
                case GargoyleState.WaitingForGlobs:
                    break;
                case GargoyleState.HasEnoughGlobs:
                    MakeAKey();
                    break;
                case GargoyleState.EndInteractions:
                    break;
            }
        }
    }

    public void Introduction()
    {
        hadFirstInteraction = true;
        goyleState = GargoyleState.WaitingForGlobs;
        //hide alert
        alert.gameObject.SetActive(false);
        //disable player movement 

        //stop ghosts searching (ghosts pause or go to spawn point)
        //switch camera priority

        //establish camera for cutscene
        GameManager.instance.vc_cutscene = vcam;
        //change gamemanager to ShowCutScene
        GameManager.instance.ShowCutSceneScreen();
        //begin dialogue text
        introDialogue.TriggerDialogue();

        //
    }

    //call if the number of globs drops below required amount
    public void HasNotEnoughGlobs()
    {
        if (gaveKey || !hadFirstInteraction) return;
        goyleState = GargoyleState.WaitingForGlobs;
        alert.gameObject.SetActive(false);
    }

    //call this when the player has 25 globs
    public void HasEnoughGlobs()
    {
        if (gaveKey || !hadFirstInteraction) return;
        goyleState = GargoyleState.HasEnoughGlobs;
        alert.gameObject.SetActive(true);
    }

    public void MakeAKey()
    {
        gaveKey = true;
        goyleState = GargoyleState.EndInteractions;
        alert.gameObject.SetActive(false);

        GameManager.instance.vc_cutscene = vcam;
        //change gamemanager to ShowCutScene
        GameManager.instance.ShowCutSceneScreen();
        //begin dialogue text
        hasEnoughGlobsDialogue.TriggerDialogue();
    }

    public void EndIntroduction()
    {
        alert.gameObject.SetActive(false);
    }

    public void SubtractGlobs()
    {
        Player.instance.SubtractGlobCount(25);
    }

    public void ResumeGame()
    {
        GameManager.instance.ResumeGame();
    }

    public void ShowKeyAward()
    {
        GameManager.instance.ShowKeyAward(keyID);
    }
}
