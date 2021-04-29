using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas TitleScreen; 
    public Canvas GameScreen;
    public Canvas PauseScreen;
    public Canvas GameOverScreen;

    public Transform spawnPosition; 


    public void ResetUI(){
        TitleScreen.gameObject.SetActive(false);
        PauseScreen.gameObject.SetActive(false);
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
