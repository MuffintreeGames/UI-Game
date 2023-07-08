using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    float timeToStart = 3f;
    bool started = false;
    static float timeMultiplier = 1f;
    static float timePlayed = 0f;
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
    }

    public static float AdjustedDeltaTime()
    {
        return Time.deltaTime * timeMultiplier;
    }

    public static float GetTimePlayed()
    {
        return timePlayed;
    }
}
