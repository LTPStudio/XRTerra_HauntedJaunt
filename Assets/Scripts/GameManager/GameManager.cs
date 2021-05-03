using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject globalPostProcessor;
    public static GameManager instance;
    public Canvas TitleScreen;
    public Canvas GameScreen;
    public Animator AwardAnimator;
    public KeyManager KeyManager;
    public TMP_Text GlobCount;
    public Canvas PauseScreen;
    public Canvas GameOverScreen;
    public Canvas CutSceneSceen;
    public CinemachineVirtualCamera vc_game;
    [HideInInspector]
    public CinemachineVirtualCamera vc_cutscene;
    public Gargoyle_Interactor[] gargoyle_interactors;

    public Transform spawnPosition;

    public int globCount; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        globalPostProcessor.SetActive(true);
    }

    void Start()
    {
        ResetUI();
        ShowTitleScreen();
    }


    public void ResetUI(bool activate = false)
    {
        TitleScreen.gameObject.SetActive(activate);
        PauseScreen.gameObject.SetActive(activate);
        GameScreen.gameObject.SetActive(activate);
        GameOverScreen.gameObject.SetActive(activate);
        CutSceneSceen.gameObject.SetActive(activate);
    }

    public void ShowPauseScreen()
    {
        EnablePlayerMovement(false);
        EnableEnemyMovement(false);
        PauseScreen.gameObject.SetActive(true);
    }

    public void ShowTitleScreen()
    {
        TitleScreen.gameObject.SetActive(true);
        EnablePlayerMovement(false);
        EnableEnemyMovement(false);
    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.gameObject.SetActive(true);
    }

    #region CUTSCENES AND AWARDS
    public void ShowCutSceneScreen()
    {
        ResetUI();
        EnableEnemyMovement(false);
        EnablePlayerMovement(false);
        vc_cutscene.Priority = 1;
        CutSceneSceen.gameObject.SetActive(true);
    }

    public void EndCutSceneScreen()
    {
        vc_cutscene.Priority = 0;
        ResumeGame();
    }

    public void ShowKeyAward(int keyID)
    {
        GameScreen.gameObject.SetActive(true);
        StartCoroutine(StartAwardDisplay(keyID));
    }

    IEnumerator StartAwardDisplay(int keyID)
    {
        AwardAnimator.SetBool("IsOpen", true);
        yield return new WaitForSeconds(2);
        AwardAnimator.SetBool("IsOpen", false);
        KeyManager.KeyCollected(keyID);
        EndCutSceneScreen();
    }
    #endregion

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        ResetUI();
        StartCoroutine(WaitAMoment(1));
        GameScreen.gameObject.SetActive(true);
    }

    IEnumerator WaitAMoment(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        EnablePlayerMovement(true);
    }

    public void ResumeGame()
    {
        ResetUI();
        EnablePlayerMovement(true);
        EnableEnemyMovement(true);
        GameScreen.gameObject.SetActive(true);
    }

    public void EnablePlayerMovement(bool isEnabled)
    {
        Player.instance.GetComponent<PlayerInput>().enabled = isEnabled;
    }

    public void EnableEnemyMovement(bool isEnabled)
    {
        EnemyManager.instance.EnabledEnemies(isEnabled);
    }


    public void UpdateGlobCount()
    {

        if (globCount >= 25)
        {
            foreach (Gargoyle_Interactor gargoyle in gargoyle_interactors)
            {
                if (gargoyle == null) return;
                gargoyle.HasEnoughGlobs();
            }
            //update gargoyles to HasEnoughGlobs()
        }
        else if (globCount < 25)
        {
            foreach (Gargoyle_Interactor gargoyle in gargoyle_interactors)
            {
                if (gargoyle == null) return;
                gargoyle.HasNotEnoughGlobs();
            }
        }
        GlobCount.text = globCount.ToString();
    }
}
