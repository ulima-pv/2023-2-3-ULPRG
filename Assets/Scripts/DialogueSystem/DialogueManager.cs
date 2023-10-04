using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    #region Eventos
    public event UnityAction<Interaction> OnDialogueStart;
    public event UnityAction<Interaction> OnDialogueNext;
    public event UnityAction OnDialogueFinish;
    #endregion

    private Dialogue currentDialogue = null;
    private int currentDialogueIndex = 0;

    private void Awake() 
    {
        Instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogueIndex = 0;
        currentDialogue = dialogue;
        OnDialogueStart?.Invoke(dialogue.interactions[currentDialogueIndex]);
    }

    public void NextDialogue()
    {
        currentDialogueIndex++;
        Interaction nextInteraction = currentDialogue.interactions[currentDialogueIndex];
        OnDialogueNext?.Invoke(nextInteraction);

    }

    public void FinishDialogue()
    {
        OnDialogueFinish?.Invoke();
    }
}
