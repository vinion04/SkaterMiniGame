using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoopingBackground : MonoBehaviour
{
    /*
        - loops the background based on time played
        - stops loop on event
    */
    private float backgroundSpeed = 0.25f;   //slow to start
    public SpriteRenderer backgroundRenderer;

    public PlayerController playerController;   //references for events
    public GameManager gameManager;

    void Start()
    {
        playerController.gameOver.AddListener(StopLoop);    //subscribe to game over event
        gameManager.winGame.AddListener(StopLoop);          //subscript to win event
    }

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);

        backgroundSpeed += .000001f * GameManager.CurrentSpeed; //some crazy stuff i did to increment the speed of the road
    }

    void StopLoop()
    {
        this.enabled = false;   //stops road
    }
}
