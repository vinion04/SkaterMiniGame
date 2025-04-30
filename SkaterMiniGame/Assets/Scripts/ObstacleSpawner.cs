using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    /*
        - handles obstacle spawning lanes
        - manages rate of spawning
        - stops spawning on end game
    */
    public List<GameObject> obstacles = new List<GameObject>(); //list of obstacles
    private int randomObstaclesIndex;

    private List<float> lanes = new List<float>();  //list to store and randomize spawn lanes
    private int randomLanesIndex;

    private float firstLaneY = 2.9f;        //where obstacles spawn
    private float secondLaneY = -1.3f;
    private float thirdLaneY = -.4f;
    private float fourthLaneY = -2f;
    public float xPosition;

    private float timeBetweenSpawn = 1f;    //time inbetween spawning objects
    private float spawnTime = 0f;   //time before spawn

    public PlayerController playerController;
    public GameManager gameManager;


    void Start()
    {
        lanes.Add(firstLaneY);  //add lanes
        lanes.Add(secondLaneY);
        lanes.Add(thirdLaneY);
        lanes.Add(fourthLaneY);

        playerController.gameOver.AddListener(StopSpawner);    //subscribe to game over event
        gameManager.winGame.AddListener(StopSpawner);          //subscribe to win game event
    }   

    void Update()
    {
        if(Time.time > spawnTime)   //if time is greater than spawn time
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;   //update spawn time with time between spawn
        }
    }

    void Spawn()
    {
        randomObstaclesIndex = Random.Range(0, obstacles.Count);    //chooses a random obstacle
        randomLanesIndex = Random.Range(0, lanes.Count);            //chooses a random lane

        float randomLane = lanes[randomLanesIndex];     //get the random lane
        GameObject randomObstacle = obstacles[randomObstaclesIndex];    //get random obstacle

        if(randomObstacle.name == "Raccoon" || randomObstacle.name == "Tire")
        {
            Instantiate(randomObstacle, transform.position + new Vector3(10f, randomLane - .7f, 0f), transform.rotation);   //have to spawn these differently bc of placement
        }
        else
            Instantiate(randomObstacle, transform.position + new Vector3(10f, randomLane, 0f), transform.rotation);

    }

    void StopSpawner()
    {
        this.enabled = false;   //to stop spawning after end game
    }

}
