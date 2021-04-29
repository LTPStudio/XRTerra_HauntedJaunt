using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver_Trigger : MonoBehaviour
{
    public static GameOver_Trigger instance;
    public GameObject Player;

    public CanvasGroup exitCanvasGroup, caughtCanvasGroup;

    bool isPlayerAtExit = false, isPlayerCaught = false;

    float fadeDuration = 1f; 

float  imageDuration = 1f; 
    float timer; 


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null){
            instance = this;
        }
    }

    public void CaughtPlayer(){
        isPlayerCaught = true;
                timer += Time.deltaTime;

        caughtCanvasGroup.alpha = timer/ fadeDuration;

        if (timer> fadeDuration + imageDuration)
        {
            SceneManager.LoadScene(0);
            print("should load scene");
            //maybe add new start screen
        }


    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            isPlayerAtExit = true;
        }
    }

    void Update(){
        if(isPlayerAtExit){
            EndLevel();
        }
    }

    void EndLevel(){
        timer += Time.deltaTime;

        exitCanvasGroup.alpha = timer/ fadeDuration;

        if (timer> fadeDuration + imageDuration)
        {
            SceneManager.LoadScene(0);
            //maybe add new start screen
        }
    }
}
