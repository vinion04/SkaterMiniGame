using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;

    public GameManager gameManager; //this needs to be in the prefabs somehow it wont stay

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    //get obstacle rigidbody
    }

    void Start()
    {
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

    void SpeedUp()
    {
        moveSpeed += 2f;
    }

}
