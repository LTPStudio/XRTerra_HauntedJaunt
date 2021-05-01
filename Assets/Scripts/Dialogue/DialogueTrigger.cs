using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public UnityEvent overEvent;

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(this, dialogue);
    }

    public void DialogueOver()
    {
        print("dialogue over");
        if (overEvent != null)
        {
            overEvent.Invoke();
        }
    }
}
