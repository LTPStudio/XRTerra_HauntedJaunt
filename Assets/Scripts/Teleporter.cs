using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestination;
    public enum TeleporterState { sendReady, receiveReady }
    public TeleporterState teleportState = TeleporterState.sendReady;
    public Teleporter otherTeleporter;
    public bool firstEncounter = true;
    public Cinemachine.CinemachineVirtualCamera vc_cutscene;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ActivateTeleport();
        }

    }

    public void ActivateTeleport()
    {
        if (firstEncounter)
        {
            GameManager.instance.vc_cutscene = this.vc_cutscene;
            GameManager.instance.ShowCutSceneScreen();
            firstEncounter = false;
            otherTeleporter.firstEncounter = false;
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        else if (!firstEncounter)
        {
            Player.instance.transform.position = teleportDestination.position;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        teleportState = TeleporterState.sendReady;

    }




}
