using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public Canvas endGameCanvas;
    public PlayerController playerController;
    public TextMeshProUGUI timerTxt;

    public UnityEvent speedUp;  //event to speed up the level

    private bool isTimerGoing;
    private float currTime;

    void Start()
    {
        endGameCanvas.enabled = false;
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
        yield return new WaitForSeconds(3f);

        endGameCanvas.enabled = true;
    }

    void UpdateTimerDisplay(float currTime)
    {
        timerTxt.text = string.Format("{0:0.0}", currTime);
    }

    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(10f);
        speedUp.Invoke();
    }
}
