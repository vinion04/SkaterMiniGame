using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gameManager;

    public float moveSpeed = 5.3f; 

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    //get obstacle rigidbody
    }

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.speedUp.AddListener(SpeedUp);
    }

     void Update()
    {
        rb.velocity = new Vector2(-moveSpeed, 0);    //move obstacle
    }

    void OnTriggerEnter2D(Collider2D other)     //if collide with barrier, destroy
    {
        if(other.tag == "back barrier")
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed");
        }
    }

    public void SpeedUp()
    {
        moveSpeed += 4.3f;
    }

}
