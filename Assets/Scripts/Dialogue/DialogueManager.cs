//https://www.youtube.com/watch?v=_nRzoTzeyxU
//Brackeys dialogue tutorial

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public static DialogueTrigger dialogueTriggerCaller;
    public Animator animator;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public TMP_Text buttonText;

    private Queue<string> sentences;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        sentences = new Queue<string>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        sentences.Clear();
    }

    public void StartDialogue(DialogueTrigger caller, Dialogue dialogue)
    {
        dialogueTriggerCaller = caller;
        buttonText.text = "Next";
        animator.SetBool("IsOpen", true);
        //print("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 1) buttonText.text = "End";
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //print(sentence);
        StopAllCoroutines(); // if the player skips before completing stop the process
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueTriggerCaller.DialogueOver();
        animator.SetBool("IsOpen", false);
        //print("End of conversation");
    }
}
