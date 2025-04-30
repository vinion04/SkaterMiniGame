using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gameManager;
    public PlayerController playerController;
    public GameOverManager gameOverManager;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    //get obstacle rigidbody
    }

    public void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        playerController.gameOver.AddListener(EndGame);

        rb.velocity = new Vector2(-GameManager.CurrentSpeed, 0);
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
        Destroy(this.gameObject);
    }

}
