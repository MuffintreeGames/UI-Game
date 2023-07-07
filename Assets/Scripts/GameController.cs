using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour //spawns objects for AI
{
    public float timeBetweenObstacles = 3f;
    float timeLeftToObstacle = 1f;
    public GameObject coin;
    public GameObject spike;
    public GameObject jumpPoint;
    public float spawnXPosition;
    public float spawnYPositionLow;
    public float spawnYPositionMid;
    public float spawnYPositionHigh;
    public float jumpXPositionLow;
    public float jumpXPositionMid;
    public float jumpXPositionHigh;
    public float jumpYPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftToObstacle -= Time.deltaTime;
        if (timeLeftToObstacle <= 0f)
        {
            timeLeftToObstacle = timeBetweenObstacles;
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        int objectType = Random.Range(0, 6);
        GameObject obstacle = null;
        int spawnHeight = Random.Range(0, 3);
        float spawnYPosition = 0f;
        float jumpXPosition = 0f;
        switch (spawnHeight)
        {
            case 0: spawnYPosition = spawnYPositionLow; jumpXPosition = jumpXPositionLow;  break;
            case 1: spawnYPosition = spawnYPositionMid; jumpXPosition = jumpXPositionMid; break;
            case 2: spawnYPosition = spawnYPositionHigh; jumpXPosition = jumpXPositionHigh; break;
        }
        Vector2 jumpPosition = new Vector2(jumpXPosition, jumpYPosition);
        Vector2 spawnPosition = new Vector2(spawnXPosition, spawnYPosition);
        bool desirable = true;
        switch (objectType)
        {
            case 0: obstacle = Instantiate(coin, spawnPosition, Quaternion.identity); break;
            case 1: obstacle = Instantiate(spike, spawnPosition, Quaternion.identity); desirable = false; break;
            case 2: obstacle = Instantiate(coin, spawnPosition, Quaternion.identity); break;
            case 3: obstacle = Instantiate(spike, spawnPosition, Quaternion.identity); desirable = false; break;
            case 4: obstacle = Instantiate(coin, spawnPosition, Quaternion.identity); break;
            case 5: obstacle = Instantiate(spike, spawnPosition, Quaternion.identity); desirable = false; break;
        }
        GameObject newJumpPoint = Instantiate(jumpPoint, jumpPosition, Quaternion.identity);
        if (spawnHeight == 0)
        {
            newJumpPoint.GetComponent<TriggerJump>().SetDesirable(!desirable);
        } else
        {
            newJumpPoint.GetComponent<TriggerJump>().SetDesirable(desirable);
        }
    }
}
