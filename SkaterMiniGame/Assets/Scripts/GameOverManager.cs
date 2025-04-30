using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameOverManager : MonoBehaviour
{

    public GameManager gameManager;
    public PlayerController playerController;

    private Button playBtn;
    private Button quitBtn;

    public UnityEvent reset;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        reset.Invoke();
    }

    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }

    void DisplayWin()
    {
        GameObject timerObject = GameObject.Find("EndTimerTxt");

        TextMeshProUGUI timerTxt = timerObject.GetComponent<TextMeshProUGUI>();
        timerTxt.text = string.Format("you made it: {0:0.0} seconds", gameManager.currTime);
    }
}
