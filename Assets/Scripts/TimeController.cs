using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    float timeToStart = 3f;
    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        StopGame();
        started = false;
        timeToStart = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            timeToStart -= Time.fixedDeltaTime;
            if (timeToStart <= 0f)
            {
                StartGame();
            }
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        Debug.Log("game starting!");
        started = true;
    }
}
