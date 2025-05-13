using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    
    public Text dialogueText;
    public Text nametText;
    
    public Animator _animator;
    
    private Queue<string> sentences;
    
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus de dialgue");
            return;
        }
        
        instance = this;
        
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        
        _animator.SetBool("isOpen",true);
        
        nametText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }
    

    void EndDialogue()
    {
        _animator.SetBool("isOpen",false);
    }
}
