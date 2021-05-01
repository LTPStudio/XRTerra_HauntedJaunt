using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas TitleScreen;
    public Canvas GameScreen;
    public Canvas PauseScreen;
    public Canvas GameOverScreen;
    public Canvas CutSceneSceen;
    public CinemachineVirtualCamera vc_game;
    public CinemachineVirtualCamera vc_cutscene;

    public Transform spawnPosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    void Start()
    {
        ResetUI(true);
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
        PauseScreen.gameObject.SetActive(true);
    }

    public void ShowTitleScreen()
    {
        TitleScreen.gameObject.SetActive(true);
    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.gameObject.SetActive(true);
    }

    public void ShowCutSceneScreen()
    {
        ResetUI();
        vc_cutscene.Priority = 1;
        CutSceneSceen.gameObject.SetActive(true);
    }

    public void EndCutSceneScreen()
    {
        vc_cutscene.Priority = 0;
        ResumeGame();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        ResetUI();
        GameScreen.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        ResetUI();
        GameScreen.gameObject.SetActive(true);
    }

}
