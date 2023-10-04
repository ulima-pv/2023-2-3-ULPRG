using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    private Transform characterImage;
    [SerializeField]
    private Transform characterText;
    [SerializeField]
    private Transform characterName;

    private void Start() 
    {
        DialogueManager.Instance.OnDialogueStart += OnDialogueStartDelegate;
        DialogueManager.Instance.OnDialogueNext += OnDialogueNextDelegate;
        DialogueManager.Instance.OnDialogueFinish += OnDialogueFinishDelegate;

        gameObject.SetActive(false);
    }


    private void OnDialogueStartDelegate(Interaction interaction)
    {
        if (interaction != null)
        {
            gameObject.SetActive(true);
            ShowInteraction(interaction);
        }
    }

    private void OnDialogueNextDelegate(Interaction interaction)
    {
        if (interaction != null)
        {
            ShowInteraction(interaction);
        }
    }

    private void OnDialogueFinishDelegate()
    {
        gameObject.SetActive(false);
    }

    private void ShowInteraction(Interaction interaction)
    {
        characterImage.GetComponent<Image>().sprite = interaction.Sprite;
        characterName.GetComponent<TextMeshProUGUI>().text = interaction.CharacterName;
        characterText.GetComponent<TextMeshProUGUI>().text = interaction.Text;
    }
}
