using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

//TODO:
// object pooling
// stop collisions with player after they win
// smooth speeding up
// make raccoon
// add story

public class GameManager : MonoBehaviour
{
    public Canvas endGameCanvas;
    public Canvas winCanvas;
    public PlayerController playerController;
    public TextMeshProUGUI timerTxt;
    public float currTime;

    public UnityEvent speedUp;  //event to speed up the level
    public UnityEvent winGame;

    private bool isTimerGoing;
    private float endTime = 60f;

    void Awake()
    {
        //singleton
    }

    void Start()
    {
        endGameCanvas.enabled = false;
        winCanvas.enabled = false;
        playerController.gameOver.AddListener(StartEndGame);

        isTimerGoing = true;

        StartCoroutine(SpeedUp());
    }

    void Update()
    {
        if(isTimerGoing)
        {
            currTime += Time.deltaTime;
            UpdateTimerDisplay(currTime);
        }
    }

    void StartEndGame()
    {
        StartCoroutine(EndGame());
        isTimerGoing = false;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);

        endGameCanvas.enabled = true;
    }

    void UpdateTimerDisplay(float currTime)
    {
        timerTxt.text = string.Format("{0:0.0}", currTime);
    }

    IEnumerator SpeedUp()
    {
        if(currTime < endTime)
        {
            yield return new WaitForSeconds(20f);
            speedUp.Invoke();
            Debug.Log("Speeding up");
            StartCoroutine(SpeedUp());
        }
        else
        {
            winGame.Invoke();
            winCanvas.enabled = true;
        }
    }
}
