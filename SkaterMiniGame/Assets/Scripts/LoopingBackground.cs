using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoopingBackground : MonoBehaviour
{
    private float backgroundSpeed = 0.3f;   //slow to start
    public SpriteRenderer backgroundRenderer;

    public PlayerController playerController;

    void Start()
    {
        playerController.gameOver.AddListener(StopLoop);    //subscribe to game over event
    }

    void Update()
    {
        //USED FROM TUTORIAL
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }

    void StopLoop()
    {
        this.enabled = false;
    }
}
