using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextBox; //references to text boxes
    public TextMeshProUGUI enterTextBox;

    public AudioSource audioSource; //references to audio stuffs
    public AudioClip carCrashEffect;

    private int dialogueStep = 0;   //dialogue step counter

    private string[] dialogueLines = new string[]   //dialogue strings
    {
        "You're on your way to the Roller Derby World Championship!",
        "When an accident happens...",
        "Hurry! Skate the rest of the way, or you'll miss it!"
    };

    void Start()
    {
        enterTextBox.enabled = true;    //make sure its enabled
        audioSource.PlayOneShot(carCrashEffect);    //play this now cuz its a long 30 second clip
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))   //enter and return cuz sometimes its picky for some reason
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        if(dialogueStep < dialogueLines.Length) //as long as there are strings to display
        {
            dialogueTextBox.text = dialogueLines[dialogueStep]; //display the string
            dialogueStep++; //increment
        }
        else
        {
            SceneManager.LoadScene("Level");    //as long as there are no more steps left, start the game !
        }
    }
}
