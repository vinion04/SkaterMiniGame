using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    private int randomObstaclesIndex;

    private List<float> lanes = new List<float>();
    private int randomLanesIndex;

    private float firstLaneY = 2.9f;        //where obstacles spawn
    private float secondLaneY = -1.3f;
    private float thirdLaneY = -.4f;
    private float fourthLaneY = -2f;
    public float xPosition = 15f;

    private float timeBetweenSpawn = 1f;
    private float spawnTime = 3f;

    public PlayerController playerController;
    public GameManager gameManager;

    void Start()
    {
        lanes.Add(firstLaneY);
        lanes.Add(secondLaneY);
        lanes.Add(thirdLaneY);
        lanes.Add(fourthLaneY);

        playerController.gameOver.AddListener(StopSpawner);    //subscribe to game over event
        gameManager.speedUp.AddListener(SpeedUp);
    }   

    void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        randomObstaclesIndex = Random.Range(0, obstacles.Count);    //chooses a random obstacle
        randomLanesIndex = Random.Range(0, lanes.Count);            //chooses a random lane

        float randomLane = lanes[randomLanesIndex];
        GameObject randomObstacle = obstacles[randomObstaclesIndex];

        if(randomObstacle.name == "Raccoon" || randomObstacle.name == "Tire")
        {
            Instantiate(randomObstacle, transform.position + new Vector3(10f, randomLane - .7f, 0f), transform.rotation);   //have to spawn these differently bc of placement
        }
        else
            Instantiate(randomObstacle, transform.position + new Vector3(10f, randomLane, 0f), transform.rotation);

        Debug.Log("Instantiating " + randomObstacle.name);
    }

    void StopSpawner()
    {
        this.enabled = false;
    }

    void SpeedUp()
    {
        spawnTime += 2f;
    }

}
