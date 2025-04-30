using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

/* 
    - manages the current time for obstacle movement
    - manages win/lose canvases
    - updates the timer on screen
*/

public class GameManager : MonoBehaviour
{
    public Canvas endGameCanvas;    //for enabling/disabling
    public Canvas winCanvas;

    public PlayerController playerController;   //to add game over listener

    public TextMeshProUGUI timerTxt;    //to update timer text

    public float currTime;  //currTime

    public UnityEvent winGame;  //unity event to invoke when timer > 60s

    private bool isTimerGoing;  //timer stuff
    private float endTime = 60f;

    public float maxSpeed = 25f;    //storing speed here cuz it relates to how long the game is running
    public float duration = 60f;
    public static float CurrentSpeed { get; private set;}

    void Start()
    {
        endGameCanvas.enabled = false;  // disable canvases for later use
        winCanvas.enabled = false;

        playerController.gameOver.AddListener(StartEndGame);    //add a listener for end game

        isTimerGoing = true;    
    }

    void Update()
    {

        float t = Mathf.Clamp01(Time.timeSinceLevelLoad / duration);
        CurrentSpeed = Mathf.Lerp(5f, maxSpeed, t);     //increase from 5 to max speed over 60 seconds

        if(isTimerGoing)
        {
            currTime += Time.deltaTime; //update time
            UpdateTimerDisplay(currTime);   
        }
    }

    void StartEndGame()
    {
        StartCoroutine(EndGame());  
        isTimerGoing = false;   //stop timer
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);    //slight delay

        endGameCanvas.enabled = true;   // makes end game canvas show up
    }

    void UpdateTimerDisplay(float currTime)
    {
        timerTxt.text = string.Format("{0:0.0}", currTime); //updates timer display to that format

        if(currTime >= endTime) //when timer exceeds 60 seconds
        {
            winGame.Invoke();   //invoke win game
            winCanvas.enabled = true;   //show win game canvas
        }
    }

}
