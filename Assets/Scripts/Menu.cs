using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Menu : MonoBehaviour
{
    public bool StartAutomatically = false;
    public CinemachineVirtualCamera vcam_Menu; 
    public CinemachineVirtualCamera vcam_Game;


    void Start(){
        if (StartAutomatically) StartGame();
    }
    public void StartGame()
    {
        print("Did button press");
        vcam_Menu.m_Priority = 0;
        vcam_Game.m_Priority = 1; 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
