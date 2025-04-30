using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextBox;
    public TextMeshProUGUI enterTextBox;

    public AudioSource audioSource;
    public AudioClip carCrashEffect;

    private int dialogueStep = 0;

    private string[] dialogueLines = new string[]
    {
        "You're on your way to the Roller Derby World Championship!",
        "When an accident happens...",
        "Hurry! Skate the rest of the way, or you'll miss it!"
    };

    void Start()
    {
        enterTextBox.enabled = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        if(dialogueStep < dialogueLines.Length)
        {
            dialogueTextBox.text = dialogueLines[dialogueStep];
            dialogueStep++;

            audioSource.PlayOneShot(carCrashEffect);
        }
        else
        {
            SceneManager.LoadScene("Level");
        }
    }
}
