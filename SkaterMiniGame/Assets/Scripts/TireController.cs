using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireController : ObstacleMover
{

    public float verticalMoveSpeed = 5f;

    void Update()
    {
        rb.velocity = new Vector2(-moveSpeed, verticalMoveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "top barrier" || other.tag == "bottom barrier")
        {
            verticalMoveSpeed = -1 * verticalMoveSpeed;
        }
        else if(other.tag == "back barrier")
        {
            Destroy(this.gameObject);
        }
    }

}
