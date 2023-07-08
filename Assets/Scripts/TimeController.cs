using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    float timeToStart = 3f;
    static bool started = false;
    static float timeMultiplier = 1f;
    static float timePlayed = 0f;
    float speedIncreaseInterval = 60f;
    float timeUntilSpeedIncrease = 60f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting timer!");
        StopGame();
        started = false;
        timeToStart = 3f;
        timePlayed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            timeToStart -= Time.deltaTime;
            if (timeToStart <= 0f)
            {
                StartGame();
            }
        } else
        {
            timePlayed += Time.deltaTime;
            timeUntilSpeedIncrease -= Time.deltaTime;
            if (timeUntilSpeedIncrease <= 0f)
            {
                timeMultiplier += 0.2f;
                timeUntilSpeedIncrease = speedIncreaseInterval;
            }
        }
    }

    public void StopGame()
    {
        timeMultiplier = 0f;
    }

    public void StartGame()
    {
        timeMultiplier = 1f;
        Debug.Log("game starting!");
        started = true;
        timeUntilSpeedIncrease = speedIncreaseInterval;
    }

    public static float AdjustedDeltaTime()
    {
        return Time.deltaTime * timeMultiplier;
    }

    public static float GetTimePlayed()
    {
        return timePlayed;
    }

    public static bool IsStarted() { return started; }
}
