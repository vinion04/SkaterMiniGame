using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;

    public UnityEvent gameOver;     //event for game over tasks
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    //get player rigidbody
        gameOver.AddListener(StopPlayer);
    }

    void Update()
    {
        float moveY = Input.GetAxis("Vertical");    //get vertical input
        rb.velocity = new Vector2(0, moveY * moveSpeed);    //move player
    }

    void OnTriggerEnter2D(Collider2D other)     //if collide with obstalce, game over
    {
        if(other.tag == "obstacle")
        {
            Debug.Log("Game Over");
            gameOver.Invoke();  //invoke game over event across scripts
            this.enabled = false; //stop player movement
        }
    }

    void StopPlayer()
    {
        animator.enabled = false;   //stop animating player
        rb.velocity = Vector3.zero; //stop moving player
    }


}
