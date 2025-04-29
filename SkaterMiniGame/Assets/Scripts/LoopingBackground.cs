using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoopingBackground : MonoBehaviour
{
    private float backgroundSpeed = 0.25f;   //slow to start
    public SpriteRenderer backgroundRenderer;

    public PlayerController playerController;
    public GameManager gameManager;

    void Start()
    {
        playerController.gameOver.AddListener(StopLoop);    //subscribe to game over event
        gameManager.winGame.AddListener(StopLoop);          //subscript to win event
        gameManager.speedUp.AddListener(SpeedUp);           //subscribe to speed up event
    }

    void Update()
    {
        //USED FROM TUTORIAL
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }

    void StopLoop()
    {
        this.enabled = false;   //stops road
    }

    void SpeedUp()
    {
        backgroundSpeed += .025f;
    }
}
