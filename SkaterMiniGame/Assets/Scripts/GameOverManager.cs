using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameOverManager : MonoBehaviour
{

    public GameManager gameManager; //references for events
    public PlayerController playerController;

    private Button playBtn; //button references
    private Button quitBtn;

    public UnityEvent reset;    //to reset the level for "try again" button

    void Start()
    {
        playBtn = GameObject.Find("RetryBtn").GetComponent<Button>(); //find buttons to use
        quitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();

        playBtn.onClick.AddListener(OnPlay);    //play game on button click
        quitBtn.onClick.AddListener(OnQuit);    //quit game on button click

        playerController.gameOver.AddListener(DisplayWin);    //subscribe to win game event
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //load level on "try again"
        reset.Invoke(); //reset level
    }

    public void OnQuit()
    {
        Application.Quit(); //quit application
        Debug.Log("Quit Game!");
    }

    void DisplayWin()
    {
        GameObject timerObject = GameObject.Find("EndTimerTxt");    //find the text

        TextMeshProUGUI timerTxt = timerObject.GetComponent<TextMeshProUGUI>(); //get the text
        timerTxt.text = string.Format("you made it: {0:0.0} seconds", gameManager.currTime);    //display score on game over screen
    }
}
