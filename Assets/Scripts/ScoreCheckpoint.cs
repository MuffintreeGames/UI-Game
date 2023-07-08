using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheckpoint : MonoBehaviour
{
    float personalTimer = 5f;
    public int targetPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        personalTimer = ScoreManager.timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.currentScore == targetPoints)
        {
            Debug.Log("score checkpoint reached! Adding " + personalTimer + " time!");
            ScoreManager.AddTime(personalTimer);
            Destroy(gameObject);
        }
        personalTimer -= Time.deltaTime;
        if (personalTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }


}
