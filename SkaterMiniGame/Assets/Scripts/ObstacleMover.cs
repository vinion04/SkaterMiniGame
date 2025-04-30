using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameManager gameManager;             //lots of references
    public PlayerController playerController;
    public GameOverManager gameOverManager;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    //get obstacle rigidbody
    }

    public void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();  //find player controller

        playerController.gameOver.AddListener(EndGame); //listen for game over

        rb.velocity = new Vector2(-GameManager.CurrentSpeed, 0);    //move the obstacle based on CurrentSpeed thats being kept track of in game manager
    }

    void OnTriggerEnter2D(Collider2D other)     //if collide with barrier, destroy
    {
        if(other.tag == "back barrier")
        {
            Destroy(this.gameObject);
        }
    }

    void EndGame()
    {
        Destroy(this.gameObject);   //make sure these are destroyed so you can't lose the game after winning it cuz of remaining objects
    }

}
