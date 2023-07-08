using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchTerrainEvent : UnityEvent
{

}
public class GameController : MonoBehaviour //spawns objects for AI
{
    public float timeBetweenObstacles = 3f;
    float timeLeftToObstacle = 1f;
    public GameObject coin;
    public GameObject spike;
    public GameObject heart;
    public GameObject jumpPoint;
    public GameObject terrainChange;
    public GameObject ground;
    public Color grassColor;
    public Color iceColor;
    public Color stoneColor;
    public Color beachColor;
    public float spawnXPosition;
    public float spawnYPositionLow;
    public float spawnYPositionMid;
    public float spawnYPositionHigh;
    public float jumpXPositionLow;
    public float jumpXPositionMid;
    public float jumpXPositionHigh;
    public float jumpYPosition;

    public static SwitchTerrainEvent switchTerrain;
    public float timeBetweenTerrainChanges = 5f;
    float timeUntilTerrain = 0f;
    int currentTerrain = 0;
    int nextTerrain = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentTerrain = 0;
        switchTerrain = new SwitchTerrainEvent();
        switchTerrain.AddListener(ActivateTerrain);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftToObstacle -= TimeController.AdjustedDeltaTime();
        if (timeLeftToObstacle <= 0f)
        {
            timeLeftToObstacle = timeBetweenObstacles;
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        int objectType;
        if (timeUntilTerrain > 0f)
        {
            objectType = Random.Range(0, 5);
        } else
        {
            //objectType = Random.Range(0, 6);
            objectType = 5;
        }
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
        bool jump = false;
        switch (objectType)
        {
            case 0: obstacle = Instantiate(coin, spawnPosition, Quaternion.identity); jump = true; break;   //spawn coin
            case 1: obstacle = Instantiate(spike, spawnPosition, Quaternion.identity); jump = true;  desirable = false; break;  //spawn spike
            case 2: obstacle = Instantiate(heart, spawnPosition, Quaternion.identity); jump = true; break;  //spawn heart
            case 3: obstacle = Instantiate(spike, spawnPosition, Quaternion.identity); jump = true; desirable = false; break;
            case 4: obstacle = Instantiate(coin, spawnPosition, Quaternion.identity); jump = true; break;
            case 5:     //spawn terrain change object
                Color terrainColor = SelectTerrain();
                GameObject terrain = Instantiate(terrainChange, new Vector3(spawnXPosition + 10f, ground.transform.position.y, -1f), Quaternion.identity) ;
                terrain.GetComponent<SpriteRenderer>().color = terrainColor;
                timeUntilTerrain = timeBetweenTerrainChanges; 
                break;
        }
        if (jump)
        {
            GameObject newJumpPoint = Instantiate(jumpPoint, jumpPosition, Quaternion.identity);
            if (spawnHeight == 0)
            {
                newJumpPoint.GetComponent<TriggerJump>().SetDesirable(!desirable);
            }
            else
            {
                newJumpPoint.GetComponent<TriggerJump>().SetDesirable(desirable);
            }
        }
    }

    Color SelectTerrain()
    {
        int terrainType = Random.Range(0, 3);
        if (terrainType == currentTerrain)
        {
            terrainType = 3;
        }
        nextTerrain = terrainType;

        switch (terrainType)
        {
            case 0: return grassColor;
            case 1: return iceColor;
            case 2: return stoneColor;
            case 3: return beachColor;
        }
        return grassColor;
    }

    void ActivateTerrain()
    {
        currentTerrain = nextTerrain;
        switch (currentTerrain)
        {
            case 0: ground.GetComponent<SpriteRenderer>().color = grassColor; break;
            case 1: ground.GetComponent<SpriteRenderer>().color = iceColor; break;
            case 2: ground.GetComponent<SpriteRenderer>().color = stoneColor; break;
            case 3: ground.GetComponent<SpriteRenderer>().color = beachColor; break;
        }
    }
}
