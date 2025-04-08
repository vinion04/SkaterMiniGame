using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    private int randomObstaclesIndex;

    private List<float> lanes = new List<float>();
    private int randomLanesIndex;

    private float firstLaneY = 2.9f;
    private float secondLaneY = -1.3f;
    private float thirdLaneY = -.4f;
    private float fourthLaneY = -2f;

    private float timeBetweenSpawn = 3f;
    private float spawnTime = 5f;

    void Start()
    {
        lanes.Add(firstLaneY);
        lanes.Add(secondLaneY);
        lanes.Add(thirdLaneY);
        lanes.Add(fourthLaneY);
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
        randomObstaclesIndex = Random.Range(0, obstacles.Count);
        randomLanesIndex = Random.Range(0, lanes.Count);

        float randomLane = lanes[randomLanesIndex];
        GameObject randomObstacle = obstacles[randomObstaclesIndex];

        if(randomObstacle.name == "Raccoon" || randomObstacle.name == "Tire")
        {
            Instantiate(randomObstacle, transform.position + new Vector3(10f, randomLane - .7f, 0f), transform.rotation);
        }
        else
            Instantiate(randomObstacle, transform.position + new Vector3(10f, randomLane, 0f), transform.rotation);

        Debug.Log("Instantiating " + randomObstacle.name);
    }

}
