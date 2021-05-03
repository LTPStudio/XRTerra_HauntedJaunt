using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public Animator animator;
    public Cinemachine.CinemachineVirtualCamera vcam;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && Player.instance.keyCount >= 3 )
        {
            GameManager.instance.vc_cutscene = vcam;
            GameManager.instance.ShowCutSceneScreen();
            StartCoroutine(WaitForCamera());

        }
    }

    IEnumerator WaitForCamera()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("IsOpen", true);
        yield return new WaitForSeconds(2f);
        GameManager.instance.EndCutSceneScreen();
    }
}
