using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool isInRange;

    void Update()
    {
        if (isInRange)
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            isInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRange = false;
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
