using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public UIHeart heart1;
    public UIHeart heart2;
    public UIHeart heart3;
    static GameObject checkpoint;

    public static int currentHealth = 3;
    public static int correctHealth = 3;

    public static float timeLimit = 5f;
    static bool countingDown = false;
    static float timeLeft = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3;
        correctHealth = 3;
        countingDown = false;
        timeLimit = 3f;
        checkpoint = (GameObject)Resources.Load("HealthCheckpoint");
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = 0;
        if (heart1.IsHeartActive())
        {
            currentHealth += 1;
        }
        if (heart2.IsHeartActive())
        {
            currentHealth += 1;
        }
        if (heart3.IsHeartActive())
        {
            currentHealth += 1;
        }
        
        if (currentHealth != correctHealth)
        {
            if (!countingDown)
            {
                Debug.Log("Bad health! Starting countdown!");
                countingDown = true;
                timeLeft = timeLimit;
            }
            else
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                        Debug.Log("Ran out of time fixing health!");
                        GameOverManager.TriggerGameOver("Incorrect health: should have been " + correctHealth + " instead of " + currentHealth);
                }
            }
        } else
        {
            if (countingDown)
            {
                Debug.Log("Fixed health! Stopping countdown!");
                countingDown = false;
            }
        }
    }

    public static void AddTime(float time)
    {
        if (countingDown && time > timeLeft)
        {
            timeLeft = time;
        }
    }

    public void ResetHealth()
    {
        heart1.AddHeart();
        heart2.AddHeart();
        heart3.AddHeart();
    }

    public static void TakeDamage() {
        if (countingDown)
        {
            Debug.Log("lost health while already counting down, creating health checkpoint!");
            GameObject newCheckpoint = Instantiate(checkpoint);
            newCheckpoint.GetComponent<HealthCheckpoint>().targetHealth = correctHealth;
        }
        correctHealth -= 1;
        if (correctHealth <= 0) //died
        {
            correctHealth = 3;
            ScoreManager.LosePoints(ScoreManager.currentScore);
            PianoController.QueueDeathSfx();
        } else
        {
            PianoController.QueueHitSfx();
        }
    }

    public static void GainHealth(int value)
    {
        correctHealth += value;
        if (correctHealth > 3)
        {
            correctHealth = 3;
            ScoreManager.GainPoints(150);
        } else if (countingDown)
        {
            Debug.Log("gained health while already counting down, creating health checkpoint!");
            GameObject newCheckpoint = Instantiate(checkpoint);
            newCheckpoint.GetComponent<HealthCheckpoint>().targetHealth = correctHealth - 1;
        }
    }

    public static bool IsCountingDown()
    {
        return countingDown;
    }
}
