using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSfx : MonoBehaviour
{
    public float timeToPlay = 5f;
    public string type = "unknown";
    float timeLeft = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("created sfx! Need to play " + type);
        timeLeft = timeToPlay;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= TimeController.AdjustedDeltaTime();
        if (timeLeft <= 0f)
        {
            Debug.Log("failed to play sfx!");
            GameOverManager.TriggerGameOver("Failed to play sound effect for " + type);
        }
    }
}
