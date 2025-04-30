using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireController : ObstacleMover     //child of obstacle mover cuz there's lots in common
{

    public float verticalMoveSpeed = 5f;    //up and down speed

    void Update()
    {
        rb.velocity = new Vector2(-GameManager.CurrentSpeed, verticalMoveSpeed);    //use CurrentSpeed from GameManager cuz its updating 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "top barrier" || other.tag == "bottom barrier") //use these barriers to switch up and down movement
        {
            verticalMoveSpeed = -1 * verticalMoveSpeed;
        }
        else if(other.tag == "back barrier")    //delete after hitting back barrier
        {
            Destroy(this.gameObject);
        }
    }

}
