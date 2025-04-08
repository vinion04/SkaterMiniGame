using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    //get player rigidbody
    }

    void Update()
    {
        float moveY = Input.GetAxis("Vertical");    //get vertical input
        rb.velocity = new Vector2(0, moveY * moveSpeed);    //move player
    }
}
