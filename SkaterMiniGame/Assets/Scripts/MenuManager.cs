using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /*
        - manages main menu buttons
        - loads story scene on play
    */
    private Button playBtn; //button references
    private Button quitBtn;

    void Start()
    {
        playBtn = GameObject.Find("PlayBtn").GetComponent<Button>(); //find buttons to use
        quitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();

        playBtn.onClick.AddListener(OnPlay);    //play game on button click
        quitBtn.onClick.AddListener(OnQuit);    //quit game on button click
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("Story");    //load next scene "story"
    }

    public void OnQuit()
    {
        Application.Quit(); //quit application
        Debug.Log("Quit Game!");
    }
}
