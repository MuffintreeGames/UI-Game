using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject startOverlay;
    public GameObject pauseOverlay;
    public TextMeshProUGUI readyText;

    float timeToStart = 3f;
    static bool started = false;
    static float timeMultiplier = 1f;
    static float timePlayed = 0f;
    float speedIncreaseInterval = 60f;
    float timeUntilSpeedIncrease = 60f;
    static float timeToDisplaySpeedup = 3f;
    public static float timeLeftInDisplaySpeedup = 0f;

    bool skipFrame = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting timer!");
        StopGame();
        started = false;
        timeToStart = 3f;
        timePlayed = 0f;
        skipFrame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (skipFrame)
        {
            skipFrame = false;
            return;
        }
        if (!started)
        {
            readyText.text = (timeToStart+0.5).ToString("F0");
            timeToStart -= Time.deltaTime;
            if (timeToStart <= 0f)
            {
                StartGame();
            }
        }
        else
        {
            timePlayed += Time.deltaTime;
            timeUntilSpeedIncrease -= Time.deltaTime;
            timeLeftInDisplaySpeedup -= Time.deltaTime;
            if (timeUntilSpeedIncrease <= 0f)
            {
                timeMultiplier += 0.2f;
                timeUntilSpeedIncrease = speedIncreaseInterval;
                timeLeftInDisplaySpeedup = timeToDisplaySpeedup;
            }
        }
    }

    public static void StopGame()
    {
        timeMultiplier = 0f;
    }

    public void StartGame()
    {
        timeMultiplier = 1f;
        Debug.Log("game starting!");
        started = true;
        timeUntilSpeedIncrease = speedIncreaseInterval;
        startOverlay.SetActive(false);
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
