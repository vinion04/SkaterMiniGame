using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    //get obstacle rigidbody
    }

    void Update()
    {
        rb.velocity = new Vector2(-moveSpeed, 0);    //move obstacle
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "back barrier")
        {
            Destroy(this.gameObject);
            Debug.Log("Collided w barrier");
        }
    }

}
