using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas TitleScreen; 
    public Canvas GameScreen;
    public Canvas PauseScreen;
    public Canvas GameOverScreen;
    public Canvas CutSceneSceen; 

    public Transform spawnPosition; 

void Awake(){
    if (instance == null){
        instance = this; 
    }
}

void Start(){
    ResetUI();
    ShowTitleScreen();
}

    public void ResetUI(){
        TitleScreen.gameObject.SetActive(false);
        PauseScreen.gameObject.SetActive(false);
        GameScreen.gameObject.SetActive(false);
        GameOverScreen.gameObject.SetActive(false);
        CutSceneSceen.gameObject.SetActive(false);
    }

    public void ShowPauseScreen(){
        PauseScreen.gameObject.SetActive(true);
    }

    public void ShowTitleScreen(){
        TitleScreen.gameObject.SetActive(true);
    }

    public void ShowGameOverScreen(){
        GameOverScreen.gameObject.SetActive(true);
    }

    public void ShowCutSceneScreen()
    {
        ResetUI();
        CutSceneSceen.gameObject.SetActive(true);
    }

    public void QuitApplication(){
        Application.Quit();
    }

    public void StartGame(){
        ResetUI();
        GameScreen.gameObject.SetActive(true);
    }

    public void ResumeGame(){
        ResetUI();
        GameScreen.gameObject.SetActive(true);
    }

}
