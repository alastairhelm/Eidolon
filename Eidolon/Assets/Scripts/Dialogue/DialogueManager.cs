using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public Queue<string> sentences;

    private bool isOpen;

    public float openTime;
    public float startOpenTime;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        this.isOpen = false;
    }

    public void Update()
    {
        if (this.isOpen) {
            if (openTime > 0) {
                openTime -= Time.deltaTime;
            } else {
                if (sentences.Count == 0) {
                    this.isOpen = false;
                    animator.SetBool("IsOpen", false);
                } else {
                    DisplayNextSentence();
                }
            }
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
            this.isOpen = true;
            this.openTime = startOpenTime;
        }
    }

    public void EndDialogue() {
        dialogueText.text = "";
        nameText.text = "";
        this.isOpen = true;
        this.openTime = startOpenTime;
    }
}
