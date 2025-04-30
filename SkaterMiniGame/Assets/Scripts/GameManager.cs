using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

// WOULD LOVE TO ADD:
// whatever object pooling is
// character falling animation after being hit
// CLEANER CODE

public class GameManager : MonoBehaviour
{
    public Canvas endGameCanvas;
    public Canvas winCanvas;
    public PlayerController playerController;
    public TextMeshProUGUI timerTxt;
    public float currTime;

    public UnityEvent winGame;

    private bool isTimerGoing;
    private float endTime = 60f;

    public float maxSpeed = 25f;
    public float duration = 60f;

    public static float CurrentSpeed { get; private set;}

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
    }

    void Update()
    {

        float t = Mathf.Clamp01(Time.timeSinceLevelLoad / duration);
        CurrentSpeed = Mathf.Lerp(5f, maxSpeed, t);

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

        if(currTime >= endTime)
        {
            winGame.Invoke();
            winCanvas.enabled = true;
        }
    }

}
